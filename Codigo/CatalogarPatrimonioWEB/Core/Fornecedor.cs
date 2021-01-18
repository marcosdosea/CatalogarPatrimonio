using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            Entrada = new HashSet<Entrada>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Telefone { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        public virtual ICollection<Entrada> Entrada { get; set; }
    }
}
