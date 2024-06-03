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
    public async Task<ActionResult<IEnumerable<Ayuda>>> ObtenerAyuda(){
        return await _context.Ayuda.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ayuda>> ObtenerBuscarAyudaId(string id){
        var ayuda = await _context.Ayuda.SingleOrDefaultAsync(e => e.Id == id);
        if(ayuda == null){
            return NotFound();
        }
        return ayuda;
    }
}