using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Material
    {
        public Material()
        {
            EntradaMaterial = new HashSet<EntradaMaterial>();
            EstoqueMaterial = new HashSet<EstoqueMaterial>();
            ServicoMaterial = new HashSet<ServicoMaterial>();
            TransferenciaMaterial = new HashSet<TransferenciaMaterial>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdTipoMaterial { get; set; }
        public byte? StatusSolicitação { get; set; }
        public byte? DeveVincularMaterial { get; set; }
        public decimal? Valor { get; set; }

        public virtual TipoMaterial IdTipoMaterialNavigation { get; set; }
        public virtual ICollection<EntradaMaterial> EntradaMaterial { get; set; }
        public virtual ICollection<EstoqueMaterial> EstoqueMaterial { get; set; }
        public virtual ICollection<ServicoMaterial> ServicoMaterial { get; set; }
        public virtual ICollection<TransferenciaMaterial> TransferenciaMaterial { get; set; }
    }
}
