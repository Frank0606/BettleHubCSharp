using BettleHubCsharp.Data;
using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BettleHubCsharp.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PreguntaController : Controller
{
    private readonly IdentityContext _context;
    private readonly IConfiguration _configuration;

    public PreguntaController(IdentityContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    // [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pregunta>>> GetPreguntas(){
        return await _context.Pregunta.AsNoTracking().ToListAsync();
    }
}