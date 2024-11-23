using Microsoft.AspNetCore.Mvc;
using GS.Application;
using GS.Application.DTOs;
using GS.Domain;

namespace GS.Web.Controllers
{
    [ApiController]
    [Route("api/[cadastrodispositivo]")]
    public class CadastroDispositivoController : ControllerBase
    {
        private readonly ICadastroDispositivoRepository _dispositivoRepository;

        public CadastroDispositivoController(ICadastroDispositivoRepository dispositivoRepository)
        {
            _dispositivoRepository = dispositivoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadastroDispositivoDto>>> GetAll()
        {
            var dispositivos = await _dispositivoRepository.GetAllDispositivosAsync();
            return Ok(dispositivos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CadastroDispositivoDto>> GetById(int id)
        {
            var dispositivo = await _dispositivoRepository.GetDispositivoByIdAsync(id);
            if (dispositivo == null) return NotFound();
            return Ok(dispositivo);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CadastroDispositivoDto dispositivoDto)
        {
            var dispositivo = new CadastroDispositivo
            {
                IdUsuario = dispositivoDto.IdUsuario,
                TipoDispositivo = dispositivoDto.TipoDispositivo,
                DataInstalacao = dispositivoDto.DataInstalacao
            };

            await _dispositivoRepository.AddDispositivoAsync(dispositivo);
            return CreatedAtAction(nameof(GetById), new { id = dispositivo.IdDispositivo }, dispositivoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CadastroDispositivoDto dispositivoDto)
        {
            if (id != dispositivoDto.IdDispositivo) return BadRequest();
            var dispositivo = new CadastroDispositivo
            {
                IdDispositivo = dispositivoDto.IdDispositivo,
                IdUsuario = dispositivoDto.IdUsuario,
                TipoDispositivo = dispositivoDto.TipoDispositivo,
                DataInstalacao = dispositivoDto.DataInstalacao
            };

            await _dispositivoRepository.UpdateDispositivoAsync(dispositivo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _dispositivoRepository.DeleteDispositivoAsync(id);
            return NoContent();
        }
    }
}