using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class EntradamaterialDTO
    {
        public int IdMaterial { get; set; }
        public int? Quantidade { get; set; }
        public int Entrada { get; set; }
        public float? Valor { get; set; }
        public int? QuantidadeUtilizada { get; set; }
    }
}
