using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class PessoaModel
    {
		[Key]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Nome")]
		[StringLength(45, MinimumLength = 5)]
		public string nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime dataNascimento { get; set; }

		[StringLength(20, MinimumLength = 11)]
        public string CPF { get; set; }

        [Required]
        [Display(Name = "E-mail")]
		[StringLength(40, MinimumLength = 5)]
        public string email { get; set; }

        [Display(Name = "Celular")]
		[StringLength(20, MinimumLength = 8)]
        public string telefone { get; set; }

        [Required]
        [Display(Name = "Senha")]
		[StringLength(100, MinimumLength = 8)]
        public string senha { get; set; }

        [Display(Name = "Estado")]
		[StringLength(45, MinimumLength = 4)]
        public string estado { get; set; }

        [Display(Name = "Cidade")]
		[StringLength(45, MinimumLength = 4)]
        public string cidade { get; set; }
        public int idEmpresa { get; set;}

        [Display(Name = "Tipo do cliente")]
        public string tipo { get; set; }

	}
}
