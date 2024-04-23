using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BettleHubCsharp.Models;

public class Pregunta{
    [Key]
    public string? Id_pregunta { get; set; }
    public required string Pregunta_pregunta { get; set; }
    public required string Respuesta_pregunta { get; set; }
}