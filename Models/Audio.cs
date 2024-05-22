using System.ComponentModel.DataAnnotations;

namespace BettleHubCsharp.Models;

public class Audio{
    public required IFormFile File { get; set; }
}