namespace GS.Application.DTOs
{
    public class CadastroDispositivoDto
    {
        public int IdDispositivo { get; set; }
        public int IdUsuario { get; set; }
        public string TipoDispositivo { get; set; }
        public DateTime DataInstalacao { get; set; }
    }
}
