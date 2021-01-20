using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class EntradaModel
    {
		[Key]
		[Display(Name = "IdEntrada")]
		[Required(ErrorMessage = "Id da Entrada é obrigatório")]
		public int IdEntrada { get; set; }

		[Display(Name = "Nota Fiscal")]
		[Required]
		public int NotaFiscal { get; set; }

		[Display(Name = "Data de Entrada")]
		[Required]
		public string DataEntrada { get; set; }
	}
}
