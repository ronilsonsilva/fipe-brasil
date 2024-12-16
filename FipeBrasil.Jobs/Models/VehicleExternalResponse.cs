namespace FipeBrasil.Jobs.Models
{
    public class VehicleExternalResponse
    {
        public int TipoVeiculo { get; set; }
        public string Valor { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int AnoModelo { get; set; }
        public string Combustivel { get; set; } = string.Empty;
        public string CodigoFipe { get; set; } = string.Empty;
        public string MesReferencia { get; set; } = string.Empty;
        public string SiglaCombustivel { get; set; } = string.Empty;
    }

}
