using GS.Application.DTOs;
using GS.Domain;

namespace GS.Application
{
    public class CadastroDispositivoService
    {
        private readonly ICadastroDispositivoRepository _dispositivoRepository;

        public CadastroDispositivoService(ICadastroDispositivoRepository dispositivoRepository)
        {
            _dispositivoRepository = dispositivoRepository;
        }

        public async Task<IEnumerable<CadastroDispositivoDto>> GetAllDispositivosAsync()
        {
            var dispositivos = await _dispositivoRepository.GetAllDispositivosAsync();
            var dispositivosDto = new List<CadastroDispositivoDto>();

            foreach (var dispositivo in dispositivos)
            {
                dispositivosDto.Add(new CadastroDispositivoDto
                {
                    IdDispositivo = dispositivo.IdDispositivo,
                    IdUsuario = dispositivo.IdUsuario,
                    TipoDispositivo = dispositivo.TipoDispositivo,
                    DataInstalacao = dispositivo.DataInstalacao
                });
            }
            return dispositivosDto;
        }

        public async Task<CadastroDispositivoDto> GetDispositivoByIdAsync(int id)
        {
            var dispositivo = await _dispositivoRepository.GetDispositivoByIdAsync(id);
            if (dispositivo == null) return null;

            return new CadastroDispositivoDto
            {
                IdDispositivo = dispositivo.IdDispositivo,
                IdUsuario = dispositivo.IdUsuario,
                TipoDispositivo = dispositivo.TipoDispositivo,
                DataInstalacao = dispositivo.DataInstalacao
            };
        }

        public async Task AddDispositivoAsync(CadastroDispositivoDto dispositivoDto)
        {
            var dispositivo = new CadastroDispositivo
            {
                IdUsuario = dispositivoDto.IdUsuario,
                TipoDispositivo = dispositivoDto.TipoDispositivo,
                DataInstalacao = DateTime.UtcNow // ou outra abordagem necessária
            };

            await _dispositivoRepository.AddDispositivoAsync(dispositivo);
        }

        public async Task UpdateDispositivoAsync(CadastroDispositivoDto dispositivoDto)
        {
            var dispositivo = new CadastroDispositivo
            {
                IdDispositivo = dispositivoDto.IdDispositivo,
                IdUsuario = dispositivoDto.IdUsuario,
                TipoDispositivo = dispositivoDto.TipoDispositivo,
                DataInstalacao = dispositivoDto.DataInstalacao
            };

            await _dispositivoRepository.UpdateDispositivoAsync(dispositivo);
        }

        public async Task DeleteDispositivoAsync(int id)
        {
            await _dispositivoRepository.DeleteDispositivoAsync(id);
        }
    }
}
