using System;
using System.Collections.Generic;

namespace Core
{
    public partial class StatusServico
    {
        public StatusServico()
        {
            Servico = new HashSet<Servico>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Servico> Servico { get; set; }
    }
}
