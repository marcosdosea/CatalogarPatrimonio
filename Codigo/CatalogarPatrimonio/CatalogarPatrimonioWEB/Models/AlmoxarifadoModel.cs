using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class AlmoxarifadoModel
    {

		[Display(Name = "IdAlmoxarifado")]
		[Key]
		[Required(ErrorMessage = "Id do almoxarifado é obrigatório")]
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Local { get; set; }
		public int IdEmpresa { get; set; }
	
	}
}
