using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GS.ViewModels
{
	public class ConfiguracaoViewModel
	{
		[Required(ErrorMessage = "O ID da configuração é obrigatório.")]
		public int IdConfiguracao { get; set; }

		[Required(ErrorMessage = "O ID do usuário é obrigatório.")]
		public int IdUsuario { get; set; }

		[Required(ErrorMessage = "O limite de alerta é obrigatório.")]
		[Range(0, Double.MaxValue, ErrorMessage = "O limite de alerta deve ser um valor positivo.")]
		public decimal LimiteAlerta { get; set; }

		[DataType(DataType.Date)]
		public DateTime? HorarioCorteInicio { get; set; }

		[DataType(DataType.Date)]
		public DateTime? HorarioCorteFim { get; set; }

		[StringLength(500, ErrorMessage = "As preferências devem ter no máximo 500 caracteres.")]
		public string Preferencias { get; set; }
	}
}