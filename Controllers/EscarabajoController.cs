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
    public async Task<ActionResult<Escarabajo>> GetEscarabajoNombreComun(string nombreComun)
    {
        var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Nombre_comun_escarabajo == nombreComun); //Esto es para buscar otro atributo que no sea la llave
        if (escarabajo == null)
        {
            return NotFound();
        }
        return escarabajo;
    }

    [HttpGet("Especie/{especie}")]
    public async Task<ActionResult<Escarabajo>> GetEscarabajoEspecie(string especie)
    {
        var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie_escarabajo == especie); //Esto es para buscar otro atributo que no sea la llave
        if (escarabajo == null)
        {
            return NotFound();
        }
        return escarabajo;
    }

    //Este metodo es para insertar un biologo
    [HttpPost]
    public async Task<ActionResult<Escarabajo>> PostEscarabajo()
    {
        return CreatedAtAction(nameof(GetEscarabajoEspecie), new {}, null);
    }

    //Este es el metodo para editar un biologo
    [HttpPut("{especie}")]
    public async Task<IActionResult> PutEscarabajo(int especie, EscarabajoDTO escarabajoDTO)
    {
        var escarabajo = await _context.Escarabajo.FindAsync(especie);
        if(escarabajo == null)
        {
            return NotFound();
        } 

        escarabajo.Especie_escarabajo = escarabajoDTO.Especie_escarabajo;
        escarabajo.Familia_escarabajo = escarabajoDTO.Familia_escarabajo;
        escarabajo.Genero_escarabajo = escarabajoDTO.Genero_escarabajo;
        escarabajo.Patas_escarabajo = escarabajoDTO.Patas_escarabajo;
        escarabajo.Torax_escarabajo = escarabajoDTO.Torax_escarabajo;
        escarabajo.Ciclo_vida_escarabajo = escarabajoDTO.Ciclo_vida_escarabajo;
        escarabajo.Nombre_comun_escarabajo = escarabajoDTO.Nombre_comun_escarabajo;
        escarabajo.Antena_escarabajo = escarabajoDTO.Antena_escarabajo;
        escarabajo.Ojos_escarabajos = escarabajoDTO.Ojos_escarabajos;
        escarabajo.Mandibula_escarabajo = escarabajoDTO.Mandibula_escarabajo;
        escarabajo.Alas_escarabajo = escarabajoDTO.Alas_escarabajo;
        escarabajo.Elitros_escarabajo = escarabajoDTO.Elitros_escarabajo;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    //Este es el metodo para eliminar un biologo por ID
    [HttpDelete("{especie}")]
    public async Task<IActionResult> DeleteEscarabajo(string especie)
    {
        var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie_escarabajo == especie);
        if (escarabajo == null)
        {
            return NotFound();
        }

        if (escarabajo.Protegida)
        {
            return BadRequest();
        }

        _context.Escarabajo.Remove(escarabajo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}