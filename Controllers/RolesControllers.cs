using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BettleHubCsharp.Models;
using BettleHubCsharp.Data;
using Microsoft.AspNetCore.Authorization;

namespace BettleHubCsharp.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RolesController(IdentityContext context) : Controller {
    // [Authorize(Roles = "Biologo,Administrador")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserRolDTO>>> GetRoles() {
        var roles = new List<UserRolDTO>();
        foreach (var rol in await context.Roles.AsNoTracking().ToListAsync())
        {
            roles.Add(new UserRolDTO{
                Id = rol.Id,
                Nombre = rol.Name!
            });
        }
        return roles;
    }
}