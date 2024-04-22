using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BettleHubCsharp.Data;
using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BettleHubCsharp.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CuentaController : Controller
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;

    public CuentaController(DataContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<ActionResult<Cuenta>> IniciarSesion(Cuenta cuenta){

        var usuario =  await _context.Biologo.AsNoTracking().FirstOrDefaultAsync(u => u.Usuario_biologo == cuenta.Usuario_biologo);

        if(usuario != null){
            var hasher = new PasswordHasher<IdentityBiologo>();
            var result = hasher.VerifyHashedPassword(null, usuario.Contrasena_biologo, cuenta.Contrasena_biologo);

            if(result == PasswordVerificationResult.Success){

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Sid, usuario.Id_biologo),
                    new Claim(ClaimTypes.Name, usuario.Usuario_biologo),
                    new Claim(ClaimTypes.Email, usuario.Correo_biologo),
                    new Claim(ClaimTypes.GivenName, usuario.Nombre_biologo)
                };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var tokenDescriptor = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

                return Ok(new {
                    usuario.Id_biologo,
                    usuario.Correo_biologo,
                    usuario.Nombre_biologo,
                    AccessToken = jwt
                });

            }
        }

        return Unauthorized();
    }
}