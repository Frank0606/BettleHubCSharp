using BettleHubCsharp.Models;
using BettleHubCsharp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Threading.Tasks;

namespace BettleHubCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController(IdentityContext context) : Controller
    {
        private readonly IdentityContext _context = context;

        [Authorize(Roles = "Biologo,Administrador")]
        [HttpPost("imagen")]
        public async Task<ActionResult> GuardarImagen([FromForm] IFormFile imagen)
        {
            if (imagen == null || imagen.Length == 0)
                return BadRequest("No se ha subido ningún archivo.");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/css/resources/images", Guid.NewGuid() + Path.GetExtension(imagen.FileName));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            return Ok(new { message = "Archivo subido con éxito", filePath });
        }

        [Authorize(Roles = "Biologo,Administrador")]
        [HttpPost("audio")]
        public async Task<ActionResult> GuardarAudio([FromForm] IFormFile audio)
        {
            if (audio == null || audio.Length == 0)
                return BadRequest("No se ha subido ningún archivo.");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/css/resources/audios", Guid.NewGuid() + Path.GetExtension(audio.FileName));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await audio.CopyToAsync(stream);
            }

            return Ok(new { message = "Archivo subido con éxito", filePath });
        }
    }
}