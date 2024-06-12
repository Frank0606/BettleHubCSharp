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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Escarabajo>>> GetEscarabajos()
    {
        try
        {
            return await _context.Escarabajo.AsNoTracking().ToListAsync();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al obtener los escarabajos: {ex.Message}");
        }
    }

    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet("Nombre/{nombreComun}")]
    public async Task<ActionResult<Escarabajo>> GetEscarabajoNombreComun(string nombreComun)
    {
        try
        {
            var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Nombre_comun == nombreComun);
            if (escarabajo == null)
            {
                return NotFound("Escarabajo no encontrado");
            }
            return escarabajo;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al obtener el escarabajo: {ex.Message}");
        }
    }

    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet("Especie/{especie}")]
    public async Task<ActionResult<Escarabajo>> GetEscarabajoEspecie(string especie)
    {
        try
        {
            var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie == especie);
            if (escarabajo == null)
            {
                return NotFound("Escarabajo no encontrado");
            }
            return escarabajo;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al obtener el escarabajo: {ex.Message}");
        }
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public async Task<ActionResult<Escarabajo>> PostEscarabajo(EscarabajoDTO escarabajoDTO)
    {
        try
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
        catch (DbException ex)
        {
            return StatusCode(500, $"Error al insertar el escarabajo: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error inesperado: {ex.Message}");
        }
    }

    [Authorize(Roles = "Administrador")]
    [HttpPut("put/{especie}")]
    public async Task<IActionResult> PutEscarabajo(string especie, EscarabajoDTO escarabajoDTO)
    {
        try
        {
            var escarabajo = await _context.Escarabajo.FindAsync(especie);
            if (escarabajo == null)
            {
                return NotFound("Escarabajo no encontrado");
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
        catch (DbException ex)
        {
            return StatusCode(500, $"Error al actualizar el escarabajo: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error inesperado: {ex.Message}");
        }
    }

    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{especie}")]
    public async Task<IActionResult> DeleteEscarabajo(string especie)
    {
        try
        {
            var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie == especie);
            if (escarabajo == null)
            {
                return NotFound("Escarabajo no encontrado");
            }

            if (escarabajo.Protegida)
            {
                return BadRequest("El escarabajo está protegido y no puede ser eliminado");
            }

            _context.Escarabajo.Remove(escarabajo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (DbException ex)
        {
            return StatusCode(500, $"Error al eliminar el escarabajo: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error inesperado: {ex.Message}");
        }
    }

    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet("get/coordenadas/{especie}")]
    public async Task<ActionResult<List<string>>> GetCoordenadas(string especie)
    {
        try
        {
            var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie == especie);
            if (escarabajo == null)
            {
                return NotFound("Escarabajo no encontrado");
            }
            List<string> coordenadas = escarabajo.Coordenadas.ToList();
            return coordenadas;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al obtener las coordenadas: {ex.Message}");
        }
    }

    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet("get/imagenes/{especie}")]
    public async Task<ActionResult<List<string>>> GetImagenes(string especie)
    {
        try
        {
            var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie == especie);
            if (escarabajo == null)
            {
                return NotFound("Escarabajo no encontrado");
            }
            List<string> imagenes = escarabajo.Imagenes.ToList();
            return imagenes;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al obtener las imágenes: {ex.Message}");
        }
    }

    [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet("get/audios/{especie}")]
    public async Task<ActionResult<List<string>>> GetAudios(string especie)
    {
        try
        {
            var escarabajo = await _context.Escarabajo.SingleOrDefaultAsync(e => e.Especie == especie);
            if (escarabajo == null)
            {
                return NotFound("Escarabajo no encontrado");
            }
            List<string> audios = escarabajo.Audios.ToList();
            return audios;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al obtener los audios: {ex.Message}");
        }
    }

    [HttpGet("filtrar")]
    public async Task<ActionResult<IEnumerable<Escarabajo>>> FiltrarEscarabajos(
        [FromQuery] string? familia,
        [FromQuery] int? patas,
        [FromQuery] int? antenas,
        [FromQuery] bool? investigacion)
    {
        try
        {
            var query = _context.Escarabajo.AsQueryable();

            if (!string.IsNullOrEmpty(familia))
            {
                query = query.Where(e => e.Familia.Contains(familia));
            }

            if (patas.HasValue)
            {
                query = query.Where(e => e.Patas == patas.Value);
            }

            if (antenas.HasValue)
            {
                query = query.Where(e => e.Antena == antenas.Value);
            }

            if (investigacion.HasValue)
            {
                query = query.Where(e => e.Estado_investigacion == investigacion.Value);
            }

            return await query.AsNoTracking().ToListAsync();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al filtrar los escarabajos: {ex.Message}");
        }
    }
}
