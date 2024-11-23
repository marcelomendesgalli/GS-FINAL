using GS.Application;
using GS.Domain;
using Microsoft.EntityFrameworkCore;

namespace GS.Infrastructure.Repositories
{
    public class CadastroDispositivoRepository : ICadastroDispositivoRepository
    {
        private readonly ApplicationDbContext _context;

        public CadastroDispositivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CadastroDispositivo>> GetAllDispositivosAsync()
        {
            return await _context.CadastroDispositivos.ToListAsync();
        }

        public async Task<CadastroDispositivo> GetDispositivoByIdAsync(int id)
        {
            return await _context.CadastroDispositivos.FindAsync(id);
        }

        public async Task AddDispositivoAsync(CadastroDispositivo dispositivo)
        {
            await _context.CadastroDispositivos.AddAsync(dispositivo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDispositivoAsync(CadastroDispositivo dispositivo)
        {
            _context.CadastroDispositivos.Update(dispositivo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDispositivoAsync(int id)
        {
            var dispositivo = await GetDispositivoByIdAsync(id);
            if (dispositivo != null)
            {
                _context.CadastroDispositivos.Remove(dispositivo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
