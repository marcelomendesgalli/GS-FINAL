namespace GS.Domain
{
    public class Fatura
    {
        public int IdFatura { get; set; }
        public int IdUsuario { get; set; }
        public int IdDispositivo { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Status { get; set; }

        // Navegação
        public Usuario Usuario { get; set; }
        public CadastroDispositivo Dispositivo { get; set; }
    }
}
