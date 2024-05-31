using Microsoft.AspNetCore.Mvc;
using BettleHubCsharp.Models;
using BettleHubCsharp.Services;
using System.Collections.Concurrent;
using System.Net.Mail;
using Microsoft.IdentityModel.Tokens;

namespace BettleHubCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController(IEmailSender emailSender) : ControllerBase
    {
        private readonly IEmailSender _emailSender = emailSender;
        private static readonly ConcurrentDictionary<string, string> _verificationCodes = new();

        [HttpPost("enviarCorreo")]
        public async Task<IActionResult> EnviarCorreo([FromBody] EmailRequest request)
        {
            if (string.IsNullOrEmpty(request.Email))
                return BadRequest("Email es requerido");

            string codigo = GenerateRandomCode();
            _verificationCodes[request.Email] = codigo;

            string mensaje = $"Tu código de recuperación es: {codigo}";

            try
            {
                await _emailSender.SendEmailAsync(request.Email, "Correo de recuperación", mensaje);
            }
            catch (SmtpException ex)
            {
                return StatusCode(500, $"Error al enviar el correo: {ex.Message}");
            }

            return Ok();
        }

        [HttpPost("verificarCodigo")]
        public IActionResult VerificarCodigo([FromBody] CodigoVerificacionRequest request)
        {
            if (_verificationCodes.TryGetValue(request.Email, out string? savedCode))
            {
                if (savedCode == request.Codigo)
                {
                    _verificationCodes.TryRemove(request.Email, out _);
                    return Ok();
                }
                return BadRequest("Código incorrecto");
            }
            return BadRequest("Código no encontrado para el email proporcionado");
        }

        [HttpPost("comprobarCorreo")]
        public IActionResult ComprobarCorreo([FromBody] EmailRequest email){
            if (_verificationCodes.TryGetValue(email.Email, out string? savedCode)){
                return Ok();
            }
            return BadRequest("No esta registrado el correo");
        }
        private static string GenerateRandomCode()
        {
            Random random = new();
            int code = random.Next(1000, 9999);
            return code.ToString().PadLeft(6, '0');
        }
    }
}
