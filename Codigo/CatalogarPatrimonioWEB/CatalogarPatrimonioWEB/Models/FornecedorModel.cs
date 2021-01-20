using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class FornecedorModel
    {
		[Display(Name = "IdFornecedor")]
		[Key]
		[Required(ErrorMessage = "Id do fornecedor é obrigatório")]
		public int IdFornecedor { get; set; }
		[Required]
		[Display(Name = "Nome")]
		[StringLength(45, MinimumLength = 5)]
		public string Nome { get; set; }

		[Display(Name = "Categoria")]
		[StringLength(30, MinimumLength = 5)]
		public string Categoria { get; set; }

		[Display(Name = "Telefone")]
		[StringLength(14, MinimumLength = 5)]
		public string Telefone { get; set; }

		[Display(Name = "Endereco")]
		[StringLength(45, MinimumLength = 5)]
		public string Endereco { get; set; }


	}
}
