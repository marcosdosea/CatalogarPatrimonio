using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class PredioModel
    {
		[Display(Name = "IdPredio")]
		[Key]
		[Required(ErrorMessage = "Id do Predio é obrigatório")]
		public int Id { get; set; }
		[Required]
		[Display(Name = "Nome")]
		[StringLength(45, MinimumLength = 5)]
		public string Nome { get; set; }
		public int IdPredio { get; set; }
		public int IdEmpresa { get; set; }
	}
}
