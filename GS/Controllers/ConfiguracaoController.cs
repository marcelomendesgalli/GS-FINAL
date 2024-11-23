using Microsoft.AspNetCore.Mvc;
using GS.Application;
using GS.Application.DTOs;
using GS.Domain;

namespace GS.Web.Controllers
{
    [ApiController]
    [Route("api/[configuracao]")]
    public class ConfiguracaoController : ControllerBase
    {
        private readonly IConfiguracaoRepository _configuracaoRepository;

        public ConfiguracaoController(IConfiguracaoRepository configuracaoRepository)
        {
            _configuracaoRepository = configuracaoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfiguracaoDto>>> GetAll()
        {
            var configuracoes = await _configuracaoRepository.GetAllConfiguracoesAsync();
            return Ok(configuracoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConfiguracaoDto>> GetById(int id)
        {
            var configuracao = await _configuracaoRepository.GetConfiguracaoByIdAsync(id);
            if (configuracao == null) return NotFound();
            return Ok(configuracao);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ConfiguracaoDto configuracaoDto)
        {
            var configuracao = new Configuracao
            {
                IdUsuario = configuracaoDto.IdUsuario,
                LimiteAlerta = configuracaoDto.LimiteAlerta,
                HorarioCorteInicio = configuracaoDto.HorarioCorteInicio,
                HorarioCorteFim = configuracaoDto.HorarioCorteFim,
                Preferencias = configuracaoDto.Preferencias
            };

            await _configuracaoRepository.AddConfiguracaoAsync(configuracao);
            return CreatedAtAction(nameof(GetById), new { id = configuracao.IdConfiguracao }, configuracaoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ConfiguracaoDto configuracaoDto)
        {
            if (id != configuracaoDto.IdConfiguracao) return BadRequest();
            var configuracao = new Configuracao
            {
                IdConfiguracao = configuracaoDto.IdConfiguracao,
                IdUsuario = configuracaoDto.IdUsuario,
                LimiteAlerta = configuracaoDto.LimiteAlerta,
                HorarioCorteInicio = configuracaoDto.HorarioCorteInicio,
                HorarioCorteFim = configuracaoDto.HorarioCorteFim,
                Preferencias = configuracaoDto.Preferencias
            };

            await _configuracaoRepository.UpdateConfiguracaoAsync(configuracao);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _configuracaoRepository.DeleteConfiguracaoAsync(id);
            return NoContent();
        }
    }
}