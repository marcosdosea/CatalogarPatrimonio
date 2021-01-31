using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Dialogoservico = new HashSet<Dialogoservico>();
            ServicoIdAlmoxarifeNavigation = new HashSet<Servico>();
            ServicoIdSolicitanteNavigation = new HashSet<Servico>();
            ServicoIdTecnicoNavigation = new HashSet<Servico>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public int? IdEmpresa { get; set; }
        public string Tipo { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Dialogoservico> Dialogoservico { get; set; }
        public virtual ICollection<Servico> ServicoIdAlmoxarifeNavigation { get; set; }
        public virtual ICollection<Servico> ServicoIdSolicitanteNavigation { get; set; }
        public virtual ICollection<Servico> ServicoIdTecnicoNavigation { get; set; }
    }
}
