namespace GS.Domain
{
    public class CadastroDispositivo
    {
        public int IdDispositivo { get; set; }
        public int IdUsuario { get; set; }
        public string TipoDispositivo { get; set; }
        public DateTime DataInstalacao { get; set; }

        // Navegação
        public Usuario Usuario { get; set; }
        public ICollection<StatusDispositivo> Statuses { get; set; }
        public ICollection<ConsumoEnergia> Consumos { get; set; }
        public ICollection<Fatura> Faturas { get; set; }

        public CadastroDispositivo()
        {
            Statuses = new HashSet<StatusDispositivo>();
            Consumos = new HashSet<ConsumoEnergia>();
            Faturas = new HashSet<Fatura>();
        }
    }
}
