using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BettleHubCsharp.Models;

public class DatoCurioso{
    [Key]
    public string? Id_Dato { get; set; }
    public required string Descripcion_Dato { get; set; }
}