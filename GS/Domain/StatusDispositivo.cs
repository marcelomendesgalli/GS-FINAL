namespace GS.Domain
{
    public class StatusDispositivo
    {
        public int IdStatus { get; set; }
        public int IdDispositivo { get; set; }
        public string Status { get; set; }
        public DateTime DataStatus { get; set; }

        // Navegação
        public CadastroDispositivo Dispositivo { get; set; }
    }
}
