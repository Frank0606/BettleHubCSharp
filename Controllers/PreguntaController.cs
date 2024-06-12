using BettleHubCsharp.Data;
using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BettleHubCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaController(IdentityContext context, IConfiguration configuration) : Controller
    {
        private readonly IdentityContext _context = context;
        private readonly IConfiguration _configuration = configuration;

        [Authorize(Roles = "Biologo,Administrador")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pregunta>>> GetPreguntas()
        {
            try
            {
                return await _context.Pregunta.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al recuperar las preguntas. Por favor, inténtelo de nuevo más tarde.", error = ex.Message });
            }
        }
    }
}