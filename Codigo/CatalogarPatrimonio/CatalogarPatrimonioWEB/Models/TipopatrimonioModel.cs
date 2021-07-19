using System.ComponentModel.DataAnnotations;

namespace CatalogarPatrimonioWEB.Models
{
    public class TipopatrimonioModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
