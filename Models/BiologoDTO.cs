namespace BettleHubCsharp.Models;

public class BiologoDTO {
    public required string Correo { get; set; }
    public required string Contrasena { get; set; }
    public required string Nombre { get; set; }
    public required int? Edad { get; set; }
    public required long? Telefono { get; set; }
    public required string Rol { get; set; } = "Biologo";
}