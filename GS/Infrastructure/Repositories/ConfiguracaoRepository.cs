using GS.Application;
using GS.Domain;
using Microsoft.EntityFrameworkCore;

namespace GS.Infrastructure.Repositories
{
    public class ConfiguracaoRepository : IConfiguracaoRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfiguracaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Configuracao>> GetAllConfiguracoesAsync()
        {
            return await _context.Configuracoes.ToListAsync();
        }

        public async Task<Configuracao> GetConfiguracaoByIdAsync(int id)
        {
            return await _context.Configuracoes.FindAsync(id);
        }

        public async Task AddConfiguracaoAsync(Configuracao configuracao)
        {
            await _context.Configuracoes.AddAsync(configuracao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateConfiguracaoAsync(Configuracao configuracao)
        {
            _context.Configuracoes.Update(configuracao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConfiguracaoAsync(int id)
        {
            var configuracao = await GetConfiguracaoByIdAsync(id);
            if (configuracao != null)
            {
                _context.Configuracoes.Remove(configuracao);
                await _context.SaveChangesAsync();
            }
        }
    }
}