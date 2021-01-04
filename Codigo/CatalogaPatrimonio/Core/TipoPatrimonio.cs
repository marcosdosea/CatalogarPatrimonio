using System;
using System.Collections.Generic;

namespace Core
{
    public partial class TipoPatrimonio
    {
        public TipoPatrimonio()
        {
            Patrimonio = new HashSet<Patrimonio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Patrimonio> Patrimonio { get; set; }
    }
}
