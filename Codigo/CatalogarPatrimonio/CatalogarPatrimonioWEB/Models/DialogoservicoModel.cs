using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class DialogoservicoModel
    {
		[Display(Name = "IdDialogoservico")]
		[Key]
		[Required(ErrorMessage = "Id do dialogoservico é obrigatório")]
		public int IdDialogoservico { get; set; }
		[Required]
		[Display(Name = "Mensagem")]
		[StringLength(500, MinimumLength = 5)]
		public string Mensagem { get; set; }
		[Display(Name = "DataHora")]
		[StringLength(11, MinimumLength =11)]
		public string DataHora { get; set; }
	}
}
