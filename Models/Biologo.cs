using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BettleHubCsharp.Models;

public class Biologo{
    [Key]
    public int Id_biologo { get; set; }
    public required string Correo_biologo { get; set; }
    public required string Nombre_biologo { get; set; }
    public int? Edad_biologo { get; set; } = 0;
    public long? Telefono_biologo { get; set; } = 0;
    public required string Contrasena_biologo { get; set; }
    public required string Usuario_biologo { get; set; }
    public bool Protegida { get; set; } = false;

    [JsonIgnore]
    public ICollection<Escarabajo>? Escarabajos { get; set; }
}