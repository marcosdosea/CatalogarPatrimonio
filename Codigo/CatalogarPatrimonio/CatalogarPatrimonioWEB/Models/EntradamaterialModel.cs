using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogarPatrimonioWEB.Models
{
    public class EntradamaterialModel
    {
		[Key]
		public int Id { get; set; }
        public int IdMaterial { get; set; }
        public int IdEntrada { get; set; }
        public int? Quantidade { get; set; }
        public float? Valor { get; set; }
        public int? QuantidadeUtilizada { get; set; }

    }
}
