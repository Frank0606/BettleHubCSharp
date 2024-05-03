using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BettleHubCsharp.Models;

public class Escarabajo{
    [Key]
    public string? Especie { get; set; }
    public required string Familia { get; set; }
    public required string Genero { get; set; }
    public required int Patas { get; set; }
    public required string Torax { get; set; }
    public required string Ciclo_vida { get; set; }
    public required string Nombre_comun { get; set; }
    public required int Antena { get; set; }
    public required string Ojos { get; set; }
    public required string Mandibula { get; set; }
    public required string Alas { get; set; }
    public required string Elitros { get; set; }
    public required string Descripcion { get; set; }
    public required bool Estado_investigacion { get; set; }
    public string[]? Audios { get; set; }
    public string[]? Imagenes { get; set; }  
    public string[]? Coordenadas { get; set; }
    public bool Protegida { get; set; } = false;

    [JsonIgnore]
    public ICollection<Biologo>? Biologos { get; set; }
}