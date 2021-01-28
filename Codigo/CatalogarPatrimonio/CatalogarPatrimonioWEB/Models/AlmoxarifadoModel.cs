using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class AlmoxarifadoModel
    {
<<<<<<< HEAD
		// [Display(Name = "IdAlmoxarifado")]
		// [Key]
		// [Required(ErrorMessage = "Id do almoxarifado é obrigatório")]
		public int Id { get; set; }
=======
		[Display(Name = "IdAlmoxarifado")]
		[Key]
		[Required(ErrorMessage = "Id do almoxarifado é obrigatório")]
		public int IdAlmoxarifado { get; set; }
>>>>>>> 0d45788 (Criando Crud manter local)
		[Required]
		[Display(Name = "Nome")]
		[StringLength(45, MinimumLength = 5)]

		public string Nome { get; set; }
		[Display(Name = "Local")]
		public int IdEmpresa { get; set; }
	
	}
}
