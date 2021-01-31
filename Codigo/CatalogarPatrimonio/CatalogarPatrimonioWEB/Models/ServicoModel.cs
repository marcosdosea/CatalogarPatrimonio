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

        [Required]
        [Display(TipoServico = "Tipo de Serviço")]
        [StringLength(45, MinimumLength = 5)]
        public string tipoServico { get; set; }

        [Required]
        [Display(Predio = "Prédio")]
        [StringLength(45, MinimumLength = 5)]
        public string predio { get; set; }

        [Required]
        [Display(Local = "Local")]
        [StringLength(45, MinimumLength = 5)]
        public string local { get; set; }

        [Required]
        [Display(Horario = "Horário")]
        [StringLength(45, MinimumLength = 5)]
        public string horario { get; set; }

        [Required]
        [Display(Descricao = "Descrição")]
        [StringLength(45, MinimumLength = 5)]
        public string descricao { get; set; }
    }
}
