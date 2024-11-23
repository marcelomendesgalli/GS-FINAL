namespace GS.Domain
{
    public class ConsumoEnergia
    {
        public int IdConsumo { get; set; }
        public int IdDispositivo { get; set; }
        public DateTime DataHora { get; set; }
        public int ConsumoKwh { get; set; }
        public int PrecoKwh { get; set; }

        // Navegação
        public CadastroDispositivo Dispositivo { get; set; }
    }
}
