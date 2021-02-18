using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class EntradamaterialModel
    {
		[Display(Name = "Código do Material")]
        [Key]
        public int IdMaterial { get; set; }

        [Display(Name = "Código da Entrada")]
        [Key]
        public int IdEntrada { get; set; }

        [Display(Name = "Quantidade")]
        public int? Quantidade { get; set; }

        [Display(Name = "Valor")]
        public float? Valor { get; set; }

        [Display(Name = "Quantidade Utilizada")]
        public int? QuantidadeUtilizada { get; set; }

    }
    
}
