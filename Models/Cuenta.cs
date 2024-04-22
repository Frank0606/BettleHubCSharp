using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BettleHubCsharp.Models;

public class Cuenta{
    public required string Usuario_biologo { get; set; }
    public required string Contrasena_biologo { get; set; }
}