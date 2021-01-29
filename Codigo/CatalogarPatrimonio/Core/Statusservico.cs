using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Statusservico
    {
        public Statusservico()
        {
            Servico = new HashSet<Servico>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Servico> Servico { get; set; }
    }
}
