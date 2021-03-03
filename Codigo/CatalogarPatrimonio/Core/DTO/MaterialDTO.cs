using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class MaterialDTO
    {
        [Display (Name ="Código")]
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display (Name ="Tipo")]
        public string TipoMaterial { get; set; }
        public byte? StatusSolicitacao { get; set; }
        public byte? DeveVincularMaterial { get; set; }
        public decimal? Valor { get; set; }
    }
}
