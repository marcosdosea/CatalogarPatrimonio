using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Entradamaterial
    {
        public int IdMaterial { get; set; }
        public int IdEntrada { get; set; }
        public int? Quantidade { get; set; }
        public float? Valor { get; set; }
        public int? QuantidadeUtilizada { get; set; }

        public virtual Entrada IdEntradaNavigation { get; set; }
        public virtual Material IdMaterialNavigation { get; set; }
    }
}
