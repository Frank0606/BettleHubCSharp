namespace BettleHubCsharp.Models;

public class BiologoDTO{
    public string? Id_biologo { get; set; }
    public required string Correo_biologo { get; set; }
    public required string Nombre_biologo { get; set; }
    public required int? Edad_biologo { get; set; }
    public required long? Telefono_biologo { get; set; }
    public required string Contrasena_biologo { get; set; }
    public required string Usuario_biologo { get; set; }
}