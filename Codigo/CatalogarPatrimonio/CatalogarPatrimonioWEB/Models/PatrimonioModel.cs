using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class PatrimonioModel
    {

		[Display(Name = "IdPatrimonio")]
		[Key]
		[Required(ErrorMessage = "Id do patrimonio é obrigatório")]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Nome")]
		[StringLength(45, MinimumLength = 5)]
		public string Nome { get; set; }
		
		[Display(Name = "Valor")]
		public decimal Valor { get; set; }

		[Display(Name = "QrCode")]
		public int QrCode { get; set; }

		[Display(Name = "Numero")]
		public int Numero { get; set; }
		
		[Display(Name = "IdTipoPatrimonio")]
		public int IdTipoPatrimonio { get; set; }

		[Display(Name = "IdLocal")]
		public int IdLocal { get; set; }
	}
}
