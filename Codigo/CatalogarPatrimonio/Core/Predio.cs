using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Predio
    {
        public Predio()
        {
            Disponibilidade = new HashSet<Disponibilidade>();
            Local = new HashSet<Local>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public int IdEmpresa { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Disponibilidade> Disponibilidade { get; set; }
        public virtual ICollection<Local> Local { get; set; }
    }
}
