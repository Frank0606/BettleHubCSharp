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
    public class BiologoController : Controller
    {
        private readonly IdentityContext _context;
        private readonly UserManager<Biologo> _userManager;

        // Constructor que inyecta el contexto de la base de datos y el administrador de usuarios
        public BiologoController(IdentityContext context, UserManager<Biologo> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Método para obtener todos los biólogos
        [Authorize(Roles = "Biologo,Administrador")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biologo>>> GetBiologos()
        {
            return await _context.Biologo.AsNoTracking().ToListAsync();
        }

        // Método para obtener un biólogo por su nombre de usuario
        [Authorize(Roles = "Biologo,Administrador")]
        [HttpGet("UserName/{UserName}")]
        public async Task<ActionResult<Biologo>> GetBiologoUserName(string UserName)
        {
            var biologo = await _context.Biologo.SingleOrDefaultAsync(b => b.UserName == UserName);
            if (biologo == null)
            {
                return NotFound();
            }
            return biologo;
        }

        // Método para obtener un biólogo por su ID
        [Authorize(Roles = "Biologo,Administrador")]
        [HttpGet("Id/{id}")]
        public async Task<ActionResult<Biologo>> GetBiologoId(string id)
        {
            var biologo = await _context.Biologo.FindAsync(id);
            if (biologo == null)
            {
                return NotFound();
            }
            return biologo;
        }

        // Método para insertar un nuevo biólogo
        // [Authorize(Roles = "Administrador")]
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
            await _context.SaveChangesAsync();

            try
            {
                if (biologoDTO.Administrador)
                {
                    await _userManager.AddToRoleAsync(biologo, "Administrador");
                }
                else
                {
                    await _userManager.AddToRoleAsync(biologo, "Biologo");
                }
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("Error al asignar el rol al biólogo: " + ex.Message);
            }

            return CreatedAtAction(nameof(GetBiologoId), new { id = biologo.Id }, biologo);
        }

        // Método para actualizar un biólogo existente
        // [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBiologo(string id, BiologoDTO biologoDTO)
        {
            Console.WriteLine(id);
            var biologo = await _context.Biologo.FindAsync(id);
            if (biologo == null)
            {
                return NotFound();
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
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

            return NoContent();
        }

        // Método para eliminar un biólogo por su ID
        // [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBiologo(string id)
        {
            var biologo = await _context.Biologo.FindAsync(id);
            if (biologo == null)
            {
                return NotFound();
            }

            if (biologo.Protegida)
            {
                return BadRequest();
            }

            _context.Biologo.Remove(biologo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
