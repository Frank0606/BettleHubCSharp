using BettleHubCsharp.Models;
using BettleHubCsharp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BettleHubCsharp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AyudaController(IdentityContext context) : Controller
{
    private readonly IdentityContext _context = context;

    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ayuda>>> ObtenerAyuda()
    {
        try
        {
            return await _context.Ayuda.AsNoTracking().ToListAsync();
        }
        catch (Exception ex)
        {
            return StatusCode(300, new { message = "Ocurrió un error al obtener la lista de ayudas. Por favor, inténtelo de nuevo más tarde." });
        }
    }

    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet("{id}")]
    public async Task<ActionResult<Ayuda>> ObtenerBuscarAyudaId(string id){
        try {
            var ayuda = await _context.Ayuda.SingleOrDefaultAsync(e => e.Id == id);
            if(ayuda == null){
                return NotFound(new { message = "Ayuda no encontrada"});
            }
            return ayuda;
        } catch(Exception ex) {
            return StatusCode(300, new { message = "Ocurrio un error al buscar esta ayuda" });
        }
    }
}