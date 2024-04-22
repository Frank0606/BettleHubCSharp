using System.Data.Common;
using BettleHubCsharp.Data;
using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BettleHubCsharp.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BiologoController : Controller
{

    private readonly DataContext _context;

    public BiologoController(DataContext context)
    {
        _context = context;
    }

    //Este es el metodo para recuperar todos los biologos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Biologo>>> GetBiologos()
    {
        return await _context.Biologo.AsNoTracking().ToListAsync();
    }

    //Este metodo es para recuperar un solo biologo por medio de su nombre
    [HttpGet("Nombre/{nombre}")]
    public async Task<ActionResult<Biologo>> GetBiologoNombre(string nombre)
    {
        var biologo = await _context.Biologo.SingleOrDefaultAsync(b => b.Nombre_biologo == nombre); //Esto es para buscar otro atributo que no sea la llave
        if (biologo == null)
        {
            return NotFound();
        }
        return biologo;
    }

    [HttpGet("Id/{id}")]
    public async Task<ActionResult<Biologo>> GetBiologoId(string id)
    {
        var biologo = await _context.Biologo.FindAsync(id); //Esto es exclusivo para ID o llaves primarias
        if (biologo == null)
        {
            return NotFound();
        }
        return biologo;
    }

    //Este metodo es para insertar un biologo
    [HttpPost]
    public async Task<ActionResult<Biologo>> PostBiologo(BiologoDTO biologoDTO)
    {
        var idBiologo = Guid.NewGuid().ToString();
        Biologo biologo = new()
        {
            Id_biologo = idBiologo,
            Correo_biologo = biologoDTO.Correo_biologo,
            Nombre_biologo = biologoDTO.Nombre_biologo,
            Edad_biologo = biologoDTO.Edad_biologo,
            Telefono_biologo = biologoDTO.Telefono_biologo,
            Contrasena_biologo = biologoDTO.Contrasena_biologo,
            Usuario_biologo = biologoDTO.Usuario_biologo
        };

        _context.Biologo.Add(biologo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBiologoId), new { id = biologo.Id_biologo }, biologo);
    }

    //Este es el metodo para editar un biologo
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBiologo(string id, BiologoDTO biologoDTO)
    {
        var biologo = await _context.Biologo.FindAsync(id);
        if (biologo == null)
        {
            return NotFound();
        }

        biologo.Correo_biologo = biologoDTO.Correo_biologo;
        biologo.Nombre_biologo = biologoDTO.Nombre_biologo;
        biologo.Edad_biologo = biologoDTO.Edad_biologo;
        biologo.Telefono_biologo = biologoDTO.Telefono_biologo;
        biologo.Contrasena_biologo = biologoDTO.Contrasena_biologo;
        biologo.Usuario_biologo = biologoDTO.Usuario_biologo;

        try
        {
            //_context.Entry(biologo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbException ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest();
        }

        return NoContent();
    }

    //Este es el metodo para eliminar un biologo por ID
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