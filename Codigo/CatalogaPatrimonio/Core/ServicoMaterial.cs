using System;
using System.Collections.Generic;

namespace Core
{
    public partial class ServicoMaterial
    {
        public int IdMaterial { get; set; }
        public int IdServico { get; set; }
        public int Quantidade { get; set; }
        public int IdPatrimonio { get; set; }

        public virtual Material IdMaterialNavigation { get; set; }
        public virtual Patrimonio IdPatrimonioNavigation { get; set; }
        public virtual Servico IdServicoNavigation { get; set; }
    }
}
