using System.Data.Common;
using BettleHubCsharp.Data;
using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BettleHubCsharp.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BiologoController : Controller {

    private readonly DataContext _context;

    public BiologoController(DataContext context){
        _context = context;
    }

    //Este es el metodo para recuperar un biologo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Biologo>>> GetBiologos(){
        return await _context.Biologo.AsNoTracking().ToListAsync();
    }

    /*[HttpPut]
    public async Task<ActionResult<Biologo>> ActualizarBiologo(BiologoDTO biologoDTO){

    }*/

    /*[HttpPost]
    public async Task<ActionResult<Biologo>> PostCategoria(BiologoDTO BiologoDTO){
        Biologo biologo = new(){
            Nombre = BiologoDTO.Nombre
        };

        _context.Biologo.Add(biologo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCategoria), new { id = categoria.CategoriaId }, categoria);
    }*/
}