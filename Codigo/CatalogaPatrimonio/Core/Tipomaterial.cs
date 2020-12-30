using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Tipomaterial
    {
        public Tipomaterial()
        {
            Material = new HashSet<Material>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Material> Material { get; set; }
    }
}
