using System.ComponentModel.DataAnnotations;

namespace BettleHubCsharp.Models;

public class BiologoDTO{
    public int? Id_biologo { get; set; }
    public required string Correo_biologo { get; set; }
    public required string Nombre_biologo { get; set; }
    public required int? Edad_biologo { get; set; }
    public required int? Telefono_biologo { get; set; }
    public required string Contrasena_biologo { get; set; }
    public required string Usuario_biologo { get; set; }
    
}