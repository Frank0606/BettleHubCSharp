using BettleHubCsharp.Models;
using BettleHubCsharp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
                return BadRequest(new { message = "No se ha subido ningún archivo." });

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/css/resources/images", Guid.NewGuid() + Path.GetExtension(imagen.FileName));

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }
                return Ok(new { message = "Archivo subido con éxito", filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al guardar la imagen: " + ex.Message });
            }
        }

        [Authorize(Roles = "Biologo,Administrador")]
        [HttpPost("audio")]
        public async Task<ActionResult> GuardarAudio([FromForm] IFormFile audio)
        {
            if (audio == null || audio.Length == 0)
                return BadRequest(new { message = "No se ha subido ningún archivo." });

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/css/resources/audios", Guid.NewGuid() + Path.GetExtension(audio.FileName));

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await audio.CopyToAsync(stream);
                }
                return Ok(new { message = "Archivo subido con éxito", filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al guardar el audio: " + ex.Message });
            }
        }
    }
}