using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Material
    {
        public Material()
        {
            Entradamaterial = new HashSet<Entradamaterial>();
            Estoquematerial = new HashSet<Estoquematerial>();
            Servicomaterial = new HashSet<ServicoMaterial>();
            Transferenciamaterial = new HashSet<Transferenciamaterial>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdTipoMaterial { get; set; }
        public byte? StatusSolicitação { get; set; }
        public byte? DeveVincularMaterial { get; set; }
        public decimal? Valor { get; set; }

        public virtual Tipomaterial IdTipoMaterialNavigation { get; set; }
        public virtual ICollection<Entradamaterial> Entradamaterial { get; set; }
        public virtual ICollection<Estoquematerial> Estoquematerial { get; set; }
        public virtual ICollection<ServicoMaterial> Servicomaterial { get; set; }
        public virtual ICollection<Transferenciamaterial> Transferenciamaterial { get; set; }
    }
}
