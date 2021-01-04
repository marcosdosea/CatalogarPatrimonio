using System;
using System.Collections.Generic;

namespace Core
{
    public partial class TipoServico
    {
        public TipoServico()
        {
            Servico = new HashSet<Servico>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Servico> Servico { get; set; }
    }
}
