using System.ComponentModel.DataAnnotations;

namespace BettleHubCsharp.Models;

public class Pregunta{
    [Key]
    public string? Id_pregunta { get; set; }
    public required string Pregunta_pregunta { get; set; }
    public required string Respuesta_pregunta { get; set; }
}