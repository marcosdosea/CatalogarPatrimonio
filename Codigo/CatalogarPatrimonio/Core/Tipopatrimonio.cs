using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Tipopatrimonio
    {
        public Tipopatrimonio()
        {
            Patrimonio = new HashSet<Patrimonio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Patrimonio> Patrimonio { get; set; }
    }
}
