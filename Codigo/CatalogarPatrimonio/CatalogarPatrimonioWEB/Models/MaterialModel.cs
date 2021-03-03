using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace CatalogarPatrimonioWEB.Models
{
	public class MaterialModel
	{
		[Display(Name = "Código")]
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "O nome do material é obrigatório")]
		[Display(Name = "Nome")]
		public string Nome { get; set; }

		[Display(Name = "Tipo")]
		public int IdTipoMaterial { get; set; }

		[Display(Name = "Status da Solicitacao")]
		public int StatusSolicitacao { get; set; }

		[Display(Name = "Deve Vincular Material")]
		public int DeveVincularMaterial { get; set; }

		[Display(Name = "Valor")]
		public decimal? Valor { get; set; }

		public virtual Tipomaterial IdTipoMaterialNavigation { get; set; }

	}
}