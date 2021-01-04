using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Entrada
    {
        public Entrada()
        {
            EntradaMaterial = new HashSet<EntradaMaterial>();
            MaterialEntrada = new HashSet<MaterialEntrada>();
        }

        public int Id { get; set; }
        public double NotaFiscal { get; set; }
        public DateTime DataEntrada { get; set; }
        public int IdFornecedor { get; set; }

        public virtual Fornecedor IdFornecedorNavigation { get; set; }
        public virtual ICollection<EntradaMaterial> EntradaMaterial { get; set; }
        public virtual ICollection<MaterialEntrada> MaterialEntrada { get; set; }
    }
}
