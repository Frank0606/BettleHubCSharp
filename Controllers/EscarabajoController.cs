using System.Data.Common;
using BettleHubCsharp.Data;
using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BettleHubCsharp.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EscarabajoController : Controller
{

    private readonly DataContext _context;

    public EscarabajoController(DataContext context)
    {
        _context = context;
    }

    //Este es el metodo para recuperar todos los biologos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Escarabajo>>> GetEscarabajos()
    {
        return await _context.Escarabajo.AsNoTracking().ToListAsync();
    }

    //Este metodo es para recuperar un solo biologo por medio de su nombre
    [HttpGet("Nombre/{nombreComun}")]
    public async Task<ActionResult<Escarabajo>> GetEscarabajoNombreComun()
    {
        return NoContent();
    }

    [HttpGet("Especie/{especie}")]
    public async Task<ActionResult<Escarabajo>> GetEscarabajoEspecie()
    {
        return NoContent();
    }

    //Este metodo es para insertar un biologo
    [HttpPost]
    public async Task<ActionResult<Escarabajo>> PostEscarabajo()
    {
        return CreatedAtAction(nameof(GetEscarabajoEspecie), new {}, null);
    }

    //Este es el metodo para editar un biologo
    [HttpPut("{especie}")]
    public async Task<IActionResult> PutEscarabajo()
    {
        return NoContent();
    }

    //Este es el metodo para eliminar un biologo por ID
    [HttpDelete("{especie}")]
    public async Task<IActionResult> DeleteEscarabajo()
    {
        return NoContent();
    }
}