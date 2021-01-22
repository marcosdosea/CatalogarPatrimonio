using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Local
    {
        public Local()
        {
            Patrimonio = new HashSet<Patrimonio>();
            Servico = new HashSet<Servico>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdPredio { get; set; }

        public virtual Predio IdPredioNavigation { get; set; }
        public virtual ICollection<Patrimonio> Patrimonio { get; set; }
        public virtual ICollection<Servico> Servico { get; set; }
    }
}
