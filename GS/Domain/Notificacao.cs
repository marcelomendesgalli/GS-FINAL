﻿namespace GS.Domain
{
    public class Notificacao
    {
        public int IdNotificacao { get; set; }
        public int IdUsuario { get; set; }
        public string Mensagem { get; set; }
        public string Tipo { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Lida { get; set; }

        // Navegação
        public Usuario Usuario { get; set; }
    }
}
