using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Transferenciamaterial
    {
        public int IdMaterial { get; set; }
        public int IdTransferencia { get; set; }
        public int? Quantidade { get; set; }

        public virtual Material IdMaterialNavigation { get; set; }
        public virtual Transferencia IdTransferenciaNavigation { get; set; }
    }
}
