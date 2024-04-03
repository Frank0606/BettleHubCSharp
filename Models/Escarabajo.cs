namespace BettleHubCsharp.Models;

public class Escarabajo{
    public int EscarabajoId { get; set; }
    public string Titulo { get; set; } = "Sin Titulo";
    public string Sinopsis { get; set; } = "Sin sinopsis";
    public int Anio { get; set; }
    public string Poster { get; set; } = "N/A";
    public ICollection<Biologo>? Biologos { get; set; }
}