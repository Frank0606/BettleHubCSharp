using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BettleHubCsharp.Models;
using BettleHubCsharp.Data;

namespace BettleHubCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IdentityContext context) : Controller
    {
        private readonly IdentityContext _context = context;

        // [Authorize(Roles = "Biologo,Administrador")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRolDTO>>> GetRoles()
        {
            try
            {
                var roles = new List<UserRolDTO>();
                foreach (var rol in await _context.Roles.AsNoTracking().ToListAsync())
                {
                    roles.Add(new UserRolDTO
                    {
                        Id = rol.Id,
                        Nombre = rol.Name!
                    });
                }
                return roles;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al recuperar los roles. Por favor, inténtelo de nuevo más tarde.", error = ex.Message });
            }
        }
    }
}