using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class MaterialModel
    {
		[Display(Name = "IdMaterial")]
		[Key]
		[Required(ErrorMessage = "Id do material é obrigatório")]
		public int Id { get; set; }
		
		[Required]
		[Display(Name = "Nome")]
		[StringLength(45, MinimumLength = 5)]
		public string Nome { get; set; }
		
		[Display(Name = "IdTipoMaterial")]
		public int IdTipoMaterial { get; set; }

		[Display(Name = "StatusSolicitacao")]
		public int StatusSolicitacao { get; set; }

		[Display(Name = "DeveVincularMaterial")]
		public int DeveVincularMaterial { get; set; }

		[Display(Name = "Valor")]
		public decimal? Valor { get; set; }

	}
}
