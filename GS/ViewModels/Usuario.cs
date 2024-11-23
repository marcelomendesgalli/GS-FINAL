using System;
using System.ComponentModel.DataAnnotations;

namespace GS.ViewModels
{
	public class UsuarioViewModel
	{
		[Required(ErrorMessage = "O ID do usuário é obrigatório.")]
		public int IdUsuario { get; set; }

		[Required(ErrorMessage = "O nome é obrigatório.")]
		[StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O e-mail é obrigatório.")]
		[EmailAddress(ErrorMessage = "O e-mail deve ser um endereço de e-mail válido.")]
		public string Email { get; set; }

		[StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres.")]
		public string Telefone { get; set; }

		[StringLength(250, ErrorMessage = "O endereço deve ter no máximo 250 caracteres.")]
		public string Endereco { get; set; }

		[DataType(DataType.Date)]
		public DateTime DataCriacao { get; set; }
	}
}