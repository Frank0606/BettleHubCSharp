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
    public async Task<ActionResult<IEnumerable<Ayuda>>> GetAyuda(){
        return await _context.Ayuda.AsNoTracking().ToListAsync();
    }
}