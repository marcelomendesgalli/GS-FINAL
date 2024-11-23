using GS.Domain;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;

namespace GS.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CadastroDispositivo> CadastroDispositivos { get; set; }
        public DbSet<StatusDispositivo> StatusDispositivos { get; set; }
        public DbSet<ConsumoEnergia> ConsumosEnergia { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<RelatorioConsumo> RelatoriosConsumo { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Configuracao> Configuracoes { get; set; }
    }
}
