using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Almoxarifado
    {
        public Almoxarifado()
        {
            Estoquematerial = new HashSet<Estoquematerial>();
            TransferenciaIdAlmoxarifadoDestinoNavigation = new HashSet<Transferencia>();
            TransferenciaIdAlmoxarifadoOrigemNavigation = new HashSet<Transferencia>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdEmpresa { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Estoquematerial> Estoquematerial { get; set; }
        public virtual ICollection<Transferencia> TransferenciaIdAlmoxarifadoDestinoNavigation { get; set; }
        public virtual ICollection<Transferencia> TransferenciaIdAlmoxarifadoOrigemNavigation { get; set; }
    }
}
