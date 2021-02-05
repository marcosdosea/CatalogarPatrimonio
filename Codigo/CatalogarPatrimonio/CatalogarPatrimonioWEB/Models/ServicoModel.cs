using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CatalogarPatrimonioWEB.Models
{
    public class ServicoModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data da Solicitação")]
        public DateTime DataSolicitacao { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public int IdSolicitante { get; set; }
        public int IdTipoServico { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        public DateTime? DataAutorizacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int IdStatusServico { get; set; }
        public int IdAlmoxarife { get; set; }
        public int IdTecnico { get; set; }
        public int IdLocal { get; set; }
    }
}
