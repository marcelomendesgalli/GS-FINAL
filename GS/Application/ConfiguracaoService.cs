using GS.Application.DTOs;
using GS.Domain;

namespace GS.Application
{
    public class ConfiguracaoService
    {
        private readonly IConfiguracaoRepository _configuracaoRepository;

        public ConfiguracaoService(IConfiguracaoRepository configuracaoRepository)
        {
            _configuracaoRepository = configuracaoRepository;
        }

        public async Task<IEnumerable<ConfiguracaoDto>> GetAllConfiguracoesAsync()
        {
            var configuracoes = await _configuracaoRepository.GetAllConfiguracoesAsync();
            var configuracoesDto = new List<ConfiguracaoDto>();

            foreach (var configuracao in configuracoes)
            {
                configuracoesDto.Add(new ConfiguracaoDto
                {
                    IdConfiguracao = configuracao.IdConfiguracao,
                    IdUsuario = configuracao.IdUsuario,
                    HorarioCorteInicio = configuracao.HorarioCorteInicio,
                    HorarioCorteFim = configuracao.HorarioCorteFim,
                    LimiteAlerta = configuracao.LimiteAlerta,
                    Preferencias = configuracao.Preferencias
                });
            }
            return configuracoesDto;
        }

        public async Task<ConfiguracaoDto> GetConfiguracaoByIdAsync(int id)
        {
            var configuracao = await _configuracaoRepository.GetConfiguracaoByIdAsync(id);
            if (configuracao == null) return null;

            return new ConfiguracaoDto
            {
                IdConfiguracao = configuracao.IdConfiguracao,
                IdUsuario = configuracao.IdUsuario,
                HorarioCorteInicio = configuracao.HorarioCorteInicio,
                HorarioCorteFim = configuracao.HorarioCorteFim,
                LimiteAlerta = configuracao.LimiteAlerta,
                Preferencias = configuracao.Preferencias
            };
        }

        public async Task AddConfiguracaoAsync(ConfiguracaoDto configuracaoDto)
        {
            var configuracao = new Configuracao
            {
                IdUsuario = configuracaoDto.IdUsuario,
                HorarioCorteInicio = configuracaoDto.HorarioCorteInicio,
                HorarioCorteFim = configuracaoDto.HorarioCorteFim,
                LimiteAlerta = configuracaoDto.LimiteAlerta,
                Preferencias = configuracaoDto.Preferencias
            };

            await _configuracaoRepository.AddConfiguracaoAsync(configuracao);
        }

        public async Task UpdateConfiguracaoAsync(ConfiguracaoDto configuracaoDto)
        {
            var configuracao = new Configuracao
            {
                IdConfiguracao = configuracaoDto.IdConfiguracao,
                IdUsuario = configuracaoDto.IdUsuario,
                HorarioCorteInicio = configuracaoDto.HorarioCorteInicio,
                HorarioCorteFim = configuracaoDto.HorarioCorteFim,
                LimiteAlerta = configuracaoDto.LimiteAlerta,
                Preferencias = configuracaoDto.Preferencias
            };

            await _configuracaoRepository.UpdateConfiguracaoAsync(configuracao);
        }

        public async Task DeleteConfiguracaoAsync(int id)
        {
            await _configuracaoRepository.DeleteConfiguracaoAsync(id);
        }
    }
}