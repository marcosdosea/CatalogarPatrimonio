using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CatalogarPatrimonioWEB.Models
{
	public class LocalModel
	{		
		[Display(Name = "IdLocal")]
		[Key]
		[Required(ErrorMessage = "Id do local é obrigatório")]
		public int IdLocal { get; set; }

		[Required]
		[Display(Name = "Nome")]
		[StringLength(45, MinimumLength = 5)]
		public string Nome { get; set; }	
	

	}
}
