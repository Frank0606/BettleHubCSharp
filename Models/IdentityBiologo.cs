using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BettleHubCsharp.Models {

    public class IdentityBiologo : Biologo {
        [PersonalData]
        [Display(Name = "Nombre")]

        public string? Nombre { get; set; }
    }
}