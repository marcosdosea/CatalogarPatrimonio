using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class EmpresaModel
    {
		[Display(Name = "IdEmpresa")]
		[Key]
		[Required(ErrorMessage = "Id da Empresa é obrigatório")]
		public int Id { get; set; }
		[Required]
		[Display(Name = "Nome")]
		[StringLength(45, MinimumLength = 5)]
		public string Nome { get; set; }
	}
}
