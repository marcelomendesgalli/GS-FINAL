using GS.Application.DTOs;
using GS.Domain;

namespace GS.Application
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllUsuariosAsync();

            // Mapeamento de entidades para DTOs
            var usuariosDto = new List<UsuarioDto>();
            foreach (var usuario in usuarios)
            {
                usuariosDto.Add(new UsuarioDto
                {
                    IdUsuario = usuario.IdUsuario,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Telefone = usuario.Telefone,
                    Endereco = usuario.Endereco
                });
            }
            return usuariosDto;
        }

        public async Task<UsuarioDto> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null) return null;

            return new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Endereco = usuario.Endereco
            };
        }

        public async Task AddUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Telefone = usuarioDto.Telefone,
                Endereco = usuarioDto.Endereco,
                DataCriacao = DateTime.UtcNow // Adicione a lógica de data de criação
            };

            await _usuarioRepository.AddUsuarioAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                IdUsuario = usuarioDto.IdUsuario, // Certifique-se de que o ID está presente para atualização
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Telefone = usuarioDto.Telefone,
                Endereco = usuarioDto.Endereco,
                DataCriacao = DateTime.UtcNow // Ou mantenha a data de criação existente, conforme necessário
            };

            await _usuarioRepository.UpdateUsuarioAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _usuarioRepository.DeleteUsuarioAsync(id);
        }
    }
}