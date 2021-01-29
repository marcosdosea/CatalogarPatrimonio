using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Dialogoservico
    {
        public int Id { get; set; }
        public DateTime? DataHora { get; set; }
        public string Mensagem { get; set; }
        public int IdServico { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual Servico IdServicoNavigation { get; set; }
    }
}
