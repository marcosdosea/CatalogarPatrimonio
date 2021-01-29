using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Estoquematerial
    {
        public int IdMaterial { get; set; }
        public int IdAlmoxarifado { get; set; }
        public int Quantidade { get; set; }

        public virtual Almoxarifado IdAlmoxarifadoNavigation { get; set; }
        public virtual Material IdMaterialNavigation { get; set; }
    }
}
