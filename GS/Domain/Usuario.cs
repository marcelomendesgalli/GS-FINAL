namespace GS.Domain
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public DateTime DataCriacao { get; set; }

        // Navegação para relacionamentos
        public ICollection<CadastroDispositivo> Dispositivos { get; set; }
        public ICollection<Notificacao> Notificacoes { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }
        public ICollection<RelatorioConsumo> Relatorios { get; set; }
        public ICollection<Fatura> Faturas { get; set; }
        public ICollection<Configuracao> Configuracoes { get; set; }

        public Usuario()
        {
            Dispositivos = new HashSet<CadastroDispositivo>();
            Notificacoes = new HashSet<Notificacao>();
            Pagamentos = new HashSet<Pagamento>();
            Relatorios = new HashSet<RelatorioConsumo>();
            Faturas = new HashSet<Fatura>();
            Configuracoes = new HashSet<Configuracao>();
        }
    }
}