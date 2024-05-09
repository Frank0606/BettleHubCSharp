using System.ComponentModel.DataAnnotations;

namespace BettleHubCsharp.Models;

public class Ayuda{
    [Key]
    public string? Id { get; set; }

    public required string Titulo { get; set; }

    public required string Contenido { get; set; }
}