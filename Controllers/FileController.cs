// using BettleHubCsharp.Models;
// using BettleHubCsharp.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authorization;

// namespace BettleHubCsharp.Controllers;

// [Route("api/[controller]")]
// [ApiController]
// public class FileController(IdentityContext context) : Controller
// {
//     private readonly IdentityContext _context = context;

//     [Authorize(Roles = "Biologo,Administrador")]
//     [HttpPost("{audio}")]
//     public async Task<ActionResult<IFormFile>> postAudio(Audio audio){
//         if (audio == null)
//             return BadRequest();
        
//     }
// }