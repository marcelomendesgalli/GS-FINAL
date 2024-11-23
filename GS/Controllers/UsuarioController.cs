using Microsoft.AspNetCore.Mvc;
using GS.Application;
using GS.Application.DTOs;
using GS.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace GS.Web.Controllers
{
    [ApiController]
    [Route("api/[usuario]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Telefone = usuarioDto.Telefone,
                Endereco = usuarioDto.Endereco,
                DataCriacao = DateTime.UtcNow // Ou a lógica que desejar para a data de criação
            };

            await _usuarioRepository.AddUsuarioAsync(usuario);
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Nome = usuarioDto.Nome;
            usuario.Email = usuarioDto.Email;
            usuario.Telefone = usuarioDto.Telefone;
            usuario.Endereco = usuarioDto.Endereco;

            await _usuarioRepository.UpdateUsuarioAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await _usuarioRepository.DeleteUsuarioAsync(id);
            return NoContent();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTodosUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllUsuariosAsync();
            return Ok(usuarios);
        }
    }
}