using System.ComponentModel.DataAnnotations;

namespace BettleHubCsharp.Models{

    public class LoginViewModel {

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo {0} no es correo valido.")]
        public required string Correo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}