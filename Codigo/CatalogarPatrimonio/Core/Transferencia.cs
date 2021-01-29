using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Transferencia
    {
        public Transferencia()
        {
            Transferenciamaterial = new HashSet<Transferenciamaterial>();
        }

        public int Id { get; set; }
        public int IdAlmoxarifadoOrigem { get; set; }
        public int IdAlmoxarifadoDestino { get; set; }
        public DateTime? Data { get; set; }

        public virtual Almoxarifado IdAlmoxarifadoDestinoNavigation { get; set; }
        public virtual Almoxarifado IdAlmoxarifadoOrigemNavigation { get; set; }
        public virtual ICollection<Transferenciamaterial> Transferenciamaterial { get; set; }
    }
}
