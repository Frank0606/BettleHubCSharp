using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BettleHubCsharp.Models;

public class Cuenta{
    public required string Nombre { get; set; }
    public required string Contrasena { get; set; }
}