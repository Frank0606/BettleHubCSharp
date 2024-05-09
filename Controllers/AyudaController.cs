using BettleHubCsharp.Models;
using BettleHubCsharp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BettleHubCsharp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AyudaController : Controller
{
    private readonly IdentityContext _context;

    public AyudaController(IdentityContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ayuda>>> GetAyuda(){
        return await _context.Ayuda.AsNoTracking().ToListAsync();
    }
}