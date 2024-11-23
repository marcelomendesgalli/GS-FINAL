using GS.Domain;

namespace GS.Application
{
    public interface IConfiguracaoRepository
    {
        Task<IEnumerable<Configuracao>> GetAllConfiguracoesAsync();
        Task<Configuracao> GetConfiguracaoByIdAsync(int id);
        Task AddConfiguracaoAsync(Configuracao configuracao);
        Task UpdateConfiguracaoAsync(Configuracao configuracao);
        Task DeleteConfiguracaoAsync(int id);
    }
}
