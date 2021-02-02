using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CatalogarPatrimonioWEB.Models
{
    public class AdicionarGestorModel
    {
        [Display(Name = "IdGestor")]
        [Key]
        [Required(ErrorMessage = "Id do gestor é obrigatório")]
        public int Id { get; set; }
    }
}
