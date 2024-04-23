using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BettleHubCsharp.Data;
using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BettleHubCsharp.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PreguntaController : Controller
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;

    public PreguntaController(DataContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pregunta>>> GetPreguntas(){
        return await _context.Pregunta.AsNoTracking().ToListAsync();
    }
}