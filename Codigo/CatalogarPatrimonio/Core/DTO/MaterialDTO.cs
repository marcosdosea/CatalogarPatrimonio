using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal? Valor { get; set; }
        public byte? DeveVincularMaterial { get; set; }
        public byte? StatusSolicitacao { get; set; }
    }
}
