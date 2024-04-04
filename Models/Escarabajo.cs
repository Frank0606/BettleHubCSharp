using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BettleHubCsharp.Models;

public class Escarabajo{
    [Key]
    public string? Especie_escarabajo { get; set; }
    public required string Familia_escarabajo { get; set; }
    public required string Genero_escarabajo { get; set; }
    public required int Patas_escarabajo { get; set; }
    public required string Torax_escarabajo { get; set; }
    public required string Ciclo_vida_escarabajo { get; set; }
    public required string Nombre_comun_escarabajo { get; set; }
    public required int Antena_escarabajo { get; set; }
    public required string Ojos_escarabajos { get; set; }
    public required string Mandibula_escarabajo { get; set; }
    public required string Alas_escarabajo { get; set; }
    public required string Elitros_escarabajo { get; set; }
    public string[]? Audios_escarabajo { get; set; }
    public string[]? Imagenes_escarabajo { get; set; }
    public bool Protegida { get; set; } = false;

    [JsonIgnore]
    public ICollection<Biologo>? Biologos { get; set; }
}