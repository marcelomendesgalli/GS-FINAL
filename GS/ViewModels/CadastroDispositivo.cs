using System;
using System.ComponentModel.DataAnnotations;

namespace GS.ViewModels
{
	public class CadastroDispositivoViewModel
	{
		[Required(ErrorMessage = "O ID do usuário é obrigatório.")]
		public int IdUsuario { get; set; }

		[Required(ErrorMessage = "O tipo de dispositivo é obrigatório.")]
		[StringLength(100, ErrorMessage = "O tipo de dispositivo deve ter no máximo 100 caracteres.")]
		public string TipoDispositivo { get; set; }

		[Required(ErrorMessage = "A data de instalação é obrigatória.")]
		[DataType(DataType.Date)]
		public DateTime DataInstalacao { get; set; }
	}
}