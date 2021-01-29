using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Entrada
    {
        public Entrada()
        {
            Entradamaterial = new HashSet<Entradamaterial>();
        }

        public int Id { get; set; }
        public double NotaFiscal { get; set; }
        public DateTime DataEntrada { get; set; }
        public int IdFornecedor { get; set; }

        public virtual Fornecedor IdFornecedorNavigation { get; set; }
        public virtual ICollection<Entradamaterial> Entradamaterial { get; set; }
    }
}
