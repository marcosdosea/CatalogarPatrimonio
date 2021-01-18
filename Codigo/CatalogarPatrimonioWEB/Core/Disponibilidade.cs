using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Disponibilidade
    {
        public int Id { get; set; }
        public DateTime? Dia { get; set; }
        public DateTime? Hora { get; set; }
        public int IdLocal { get; set; }

        public virtual Predio IdLocalNavigation { get; set; }
    }
}
