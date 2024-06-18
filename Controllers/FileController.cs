using BettleHubCsharp.Models;
using BettleHubCsharp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Text;

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

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\css\\resources\\images", Guid.NewGuid() + Path.GetExtension(imagen.FileName));

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
        [HttpPost("audi")]
        public async Task<ActionResult> GuardarAudio([FromForm] IFormFile audio)
        {
            if (audio == null || audio.Length == 0)

                return BadRequest(new { message = "No se ha subido ningún archivo." });

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\css\\resources\\audios", Guid.NewGuid() + Path.GetExtension(audio.FileName));

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
                return StatusCode(500, new { message = "Error al guardar el archivo de audio: " + ex.Message });
            }
        }

        [Authorize(Roles = "Biologo,Administrador")]
        [HttpPost("audio")]
        public async Task<ActionResult> GuardarAudioFlask([FromForm] IFormFile audio)
        {
            if (audio == null || audio.Length == 0)
                return BadRequest(new { message = "No se ha subido ningún archivo." });

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\css\\resources\\audios", Guid.NewGuid() + Path.GetExtension(audio.FileName));

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await audio.CopyToAsync(stream);
                }

                using (var client = new HttpClient())
                {
                    var flaskApiUrl = "http://localhost:3000/clasificador";
                    var content = new StringContent(JsonConvert.SerializeObject(new { filePath }), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(flaskApiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return Ok(new { message = responseContent });
                    }
                    else
                    {
                        // Maneja el error de la llamada a la API de Flask
                        return StatusCode((int)response.StatusCode, "Error al llamar a la API de Flask");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al guardar el audio: " + ex.Message });
            }
        }

    }
}