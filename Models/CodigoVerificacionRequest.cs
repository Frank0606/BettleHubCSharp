namespace BettleHubCsharp.Models {
    public class CodigoVerificacionRequest
    {
        public required string Email { get; set; }
        public required string Codigo { get; set; }
    }
}