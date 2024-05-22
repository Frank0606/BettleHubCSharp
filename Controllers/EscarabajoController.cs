using System.Data.Common;
using BettleHubCsharp.Data;
using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BettleHubCsharp.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EscarabajoController(IdentityContext context) : Controller
{

    private readonly IdentityContext _context = context;

    [Authorize(Roles = "Biologo,Administrador")]
    //Este es el metodo para recuperar todos los biologos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Escarabajo>>> GetEscarabajos()
    {
        return await _context.Escarabajo.AsNoTracking().ToListAsync();
    }

    //Este metodo es para recuperar un solo biologo por medio de su 
    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet("Nombre/{nombreComun}")]
    public async Task<ActionResult<Escarabajo>> GetEscarabajoNombreComun(string nombreComun)
    {
        var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Nombre_comun == nombreComun); //Esto es para buscar otro atributo que no sea la llave
        if (escarabajo == null)
        {
            return NotFound();
        }
        return escarabajo;
    }

    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet("Especie/{especie}")]
    public async Task<ActionResult<Escarabajo>> GetEscarabajoEspecie(string especie)
    {
        var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie == especie); //Esto es para buscar otro atributo que no sea la llave
        if (escarabajo == null)
        {
            return NotFound();
        }
        return escarabajo;
    }

    //Este metodo es para insertar un biologo
    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public async Task<ActionResult<Escarabajo>> PostEscarabajo(EscarabajoDTO escarabajoDTO)
    {
        Escarabajo escarabajo = new()
        {
            Especie = escarabajoDTO.Especie,
            Familia = escarabajoDTO.Familia,
            Genero = escarabajoDTO.Genero,
            Patas = escarabajoDTO.Patas,
            Torax = escarabajoDTO.Torax,
            Ciclo_vida = escarabajoDTO.Ciclo_vida,
            Nombre_comun = escarabajoDTO.Nombre_comun,
            Antena = escarabajoDTO.Antena,
            Ojos = escarabajoDTO.Ojos,
            Mandibula = escarabajoDTO.Mandibula,
            Alas = escarabajoDTO.Alas,
            Elitros = escarabajoDTO.Elitros,
            Audios = escarabajoDTO.Audios,
            Imagenes = escarabajoDTO.Imagenes,
            Estado_investigacion = escarabajoDTO.Estado_investigacion,
            Descripcion = escarabajoDTO.Descripcion,
            Coordenadas = escarabajoDTO.Coordenadas
        };

        _context.Escarabajo.Add(escarabajo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEscarabajoEspecie), new { especie = escarabajo.Especie }, escarabajo);
    }

    //Este es el metodo para editar un biologo
    [Authorize(Roles = "Administrador")]
    [HttpPut("put/{especie}")]
    public async Task<IActionResult> PutEscarabajo(string especie, EscarabajoDTO escarabajoDTO)
    {
        var escarabajo = await _context.Escarabajo.FindAsync(especie);
        if (escarabajo == null)
        {
            return NotFound();
        }

        _context.Escarabajo.Remove(escarabajo);
        await _context.SaveChangesAsync();

        Escarabajo escarabajo1 = new()
        {
            Especie = escarabajoDTO.Especie,
            Familia = escarabajoDTO.Familia,
            Genero = escarabajoDTO.Genero,
            Patas = escarabajoDTO.Patas,
            Torax = escarabajoDTO.Torax,
            Ciclo_vida = escarabajoDTO.Ciclo_vida,
            Nombre_comun = escarabajoDTO.Nombre_comun,
            Antena = escarabajoDTO.Antena,
            Ojos = escarabajoDTO.Ojos,
            Mandibula = escarabajoDTO.Mandibula,
            Alas = escarabajoDTO.Alas,
            Elitros = escarabajoDTO.Elitros,
            Estado_investigacion = escarabajoDTO.Estado_investigacion,
            Descripcion = escarabajoDTO.Descripcion
        };

        _context.Escarabajo.Add(escarabajo1);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    //Este es el metodo para eliminar un biologo por ID
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{especie}")]
    public async Task<IActionResult> DeleteEscarabajo(string especie)
    {
        var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie == especie);
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

    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet("get/coordenadas/{especie}")]
    public async Task<ActionResult<List<string>>> GetCoordenadas(string especie)
    {
        var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie == especie);
        List<string> coordendas = [.. escarabajo!.Coordenadas!];
        return coordendas;
    }

    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet("get/imagenes/{especie}")]
    public async Task<ActionResult<List<string>>> GetImagenes(string especie)
    {
        var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie == especie);
        List<string> imagenes = [.. escarabajo!.Imagenes!];
        return imagenes;
    }

    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet("get/audios/{especie}")]
    public async Task<ActionResult<List<string>>> GetAudios(string especie)
    {
        var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie == especie);
        List<string> audios = [.. escarabajo!.Audios!];
        return audios;
    }
}