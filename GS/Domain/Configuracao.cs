namespace GS.Domain
{
    public class Configuracao
    {
        public int IdConfiguracao { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? HorarioCorteInicio { get; set; }
        public DateTime? HorarioCorteFim { get; set; }
        public int LimiteAlerta { get; set; }
        public string Preferencias { get; set; }

        // Navegação
        public Usuario Usuario { get; set; }
    }
}
