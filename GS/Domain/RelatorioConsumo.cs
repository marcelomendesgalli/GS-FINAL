namespace GS.Domain
{
    public class RelatorioConsumo
    {
        public int IdRelatorio { get; set; }
        public int IdUsuario { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFim { get; set; }
        public int TotalConsumidoKwh { get; set; }
        public decimal TotalPago { get; set; }
        public string AnaliseTexto { get; set; }
        public DateTime DataCriacao { get; set; }

        // Navegação
        public Usuario Usuario { get; set; }
    }
}
