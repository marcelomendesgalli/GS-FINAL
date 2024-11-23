using GS.Domain;

namespace GS.Application
{
    public interface ICadastroDispositivoRepository
    {
        Task<IEnumerable<CadastroDispositivo>> GetAllDispositivosAsync();
        Task<CadastroDispositivo> GetDispositivoByIdAsync(int id);
        Task AddDispositivoAsync(CadastroDispositivo dispositivo);
        Task UpdateDispositivoAsync(CadastroDispositivo dispositivo);
        Task DeleteDispositivoAsync(int id);
    }
}
