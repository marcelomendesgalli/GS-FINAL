namespace GS.Domain
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public int IdUsuario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public string FormaPagamento { get; set; }
        public string StatusPagamento { get; set; }

        // Navegação
        public Usuario Usuario { get; set; }
    }
}
