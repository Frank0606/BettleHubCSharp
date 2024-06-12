using System.Data.Common;
using BettleHubCsharp.Data;
using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BettleHubCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiologoController(IdentityContext context, UserManager<Biologo> userManager) : Controller
    {
        private readonly IdentityContext _context = context;
        private readonly UserManager<Biologo> _userManager = userManager;

        [Authorize(Roles = "Biologo,Administrador")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biologo>>> GetBiologos()
        {
            try
            {
                return await _context.Biologo.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al obtener la lista de biólogos. Por favor, inténtelo de nuevo más tarde." });
            }
        }

        [Authorize(Roles = "Biologo,Administrador")]
        [HttpGet("Email/{Email}")]
        public async Task<ActionResult<Biologo>> GetBiologoUserName(string Email)
        {
            try
            {
                var biologo = await _context.Biologo.SingleOrDefaultAsync(b => b.Email == Email);

                if (biologo == null)
                {
                    return NotFound(new { message = "Biólogo no encontrado" });
                }

                return biologo;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al buscar el biólogo por email. Por favor, inténtelo de nuevo más tarde." });
            }
        }

        [Authorize(Roles = "Biologo,Administrador")]
        [HttpGet("Id/{id}")]
        public async Task<ActionResult<Biologo>> GetBiologoId(string id)
        {
            try
            {
                var biologo = await _context.Biologo.FindAsync(id);
                if (biologo == null)
                {
                    return NotFound(new { message = "Biólogo no encontrado" });
                }
                return biologo;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al buscar el biólogo por ID. Por favor, inténtelo de nuevo más tarde." });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Biologo>> PostBiologo(BiologoDTO biologoDTO)
        {
            var idBiologo = Guid.NewGuid().ToString();

            Biologo biologo = new()
            {
                Id = idBiologo,
                Email = biologoDTO.Correo,
                NormalizedEmail = biologoDTO.Correo.ToUpper(),
                UserName = biologoDTO.Nombre,
                NormalizedUserName = biologoDTO.Nombre.ToUpper(),
                Edad = biologoDTO.Edad,
                PhoneNumber = biologoDTO.Telefono,
                PasswordHash = new PasswordHasher<Biologo>().HashPassword(new Biologo(), biologoDTO.Contrasena)
            };

            _context.Biologo.Add(biologo);

            try
            {
                await _context.SaveChangesAsync();

                if (biologoDTO.Administrador)
                {
                    await _userManager.AddToRoleAsync(biologo, "Administrador");
                }
                else
                {
                    await _userManager.AddToRoleAsync(biologo, "Biologo");
                }

                return CreatedAtAction(nameof(GetBiologoId), new { id = biologo.Id }, biologo);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = "Error al asignar el rol al biólogo: " + ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al crear el biólogo. Por favor, inténtelo de nuevo más tarde." });
            }
        }

        [HttpPut("email/{id}")]
        public async Task<IActionResult> PutBiologo(string id, string contrasenaNueva)
        {
            var biologo = await _context.Biologo.FindAsync(id);
            if (biologo == null)
            {
                return NotFound(new { message = "Biólogo no encontrado" });
            }

            biologo.PasswordHash = new PasswordHasher<Biologo>().HashPassword(new Biologo(), contrasenaNueva);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbException)
            {
                return BadRequest(new { message = "Error al actualizar la contraseña del biólogo. Por favor, inténtelo de nuevo más tarde." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al actualizar la contraseña del biólogo. Por favor, inténtelo de nuevo más tarde." });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarContrasena(string id, BiologoDTO biologoDTO)
        {
            var biologo = await _context.Biologo.FindAsync(id);
            if (biologo == null)
            {
                return NotFound(new { message = "Biólogo no encontrado" });
            }

            biologo.Email = biologoDTO.Correo;
            biologo.NormalizedEmail = biologoDTO.Correo.ToUpper();
            biologo.UserName = biologoDTO.Nombre;
            biologo.NormalizedUserName = biologoDTO.Nombre.ToUpper();
            biologo.Edad = biologoDTO.Edad;
            biologo.PhoneNumber = biologoDTO.Telefono;
            biologo.PasswordHash = new PasswordHasher<Biologo>().HashPassword(new Biologo(), biologoDTO.Contrasena);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbException)
            {
                return BadRequest(new { message = "Error al actualizar los datos del biólogo. Por favor, inténtelo de nuevo más tarde." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al actualizar los datos del biólogo. Por favor, inténtelo de nuevo más tarde." });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBiologo(string id)
        {
            var biologo = await _context.Biologo.FindAsync(id);
            if (biologo == null)
            {
                return NotFound(new { message = "Biólogo no encontrado" });
            }

            if (biologo.Protegida)
            {
                return BadRequest(new { message = "No se puede eliminar un biólogo protegido." });
            }

            _context.Biologo.Remove(biologo);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al eliminar el biólogo. Por favor, inténtelo de nuevo más tarde." });
            }
        }
    }
}