using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace BettleHubCsharp.Models;

public class Biologo : IdentityUser {
    public int? Edad { get; set; } = 0;
    public long? Telefono { get; set; } = 0;
    public bool Protegida { get; set; } = false;

    [JsonIgnore]
    public ICollection<Escarabajo>? Escarabajos { get; set; }
}