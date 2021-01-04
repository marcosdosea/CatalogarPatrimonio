using System;
using System.Collections.Generic;

namespace Core
{
    public partial class MaterialEntrada
    {
        public int IdMaterial { get; set; }
        public int IdEntrada { get; set; }

        public virtual Entrada IdEntradaNavigation { get; set; }
        public virtual Material IdMaterialNavigation { get; set; }
    }
}
