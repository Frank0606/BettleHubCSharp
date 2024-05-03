using System.Security.Claims;
using BettleHubCsharp.Models;
using BettleHubCsharp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BettleHubCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : Controller
    {
        private readonly UserManager<Biologo> _userManager;
        private readonly JwtTokenService _jwtTokenService;

        // Constructor que inyecta el administrador de usuarios y el servicio de token JWT
        public CuentaController(UserManager<Biologo> userManager, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        // Método para iniciar sesión
        [HttpPost]
        public async Task<IActionResult> IniciarSesion([FromBody] Cuenta cuenta)
        {
            // Busca el usuario por su nombre
            var usuario = await _userManager.FindByNameAsync(cuenta.Nombre);

            if (usuario is null)
            {
                // Si el usuario no existe, devuelve un error de usuario incorrecto
                return Unauthorized(new { mensaje = "Usuario incorrecto." });
            }

            // Obtiene los roles del usuario
            var roles = await _userManager.GetRolesAsync(usuario);

            // Verifica la contraseña
            var hasher = new PasswordHasher<Biologo>();
            var result = hasher.VerifyHashedPassword(new Biologo(), usuario.PasswordHash!, cuenta.Contrasena);

            if (result == PasswordVerificationResult.Success)
            {
                // Si la contraseña es correcta, genera el token JWT con los claims necesarios
                var claims = new List<Claim> {
                    new(ClaimTypes.Sid, usuario.Id!),
                    new(ClaimTypes.Name, usuario.UserName!),
                    new(ClaimTypes.Role, roles.First()) // Tomamos solo el primer rol del usuario
                };

                var jwt = _jwtTokenService.GeneraToken(claims);

                // Devuelve información básica del usuario junto con el token JWT
                return Ok(new
                {
                    usuario.Id,
                    usuario.Email,
                    usuario.UserName,
                    AccessToken = jwt
                });
            }

            // Si la contraseña es incorrecta, devuelve un error de contraseña incorrecta
            return Unauthorized(new { mensaje = "Contraseña incorrecta." });
        }
    }
}