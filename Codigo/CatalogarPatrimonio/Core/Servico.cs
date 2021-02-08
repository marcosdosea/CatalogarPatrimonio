using System;
using System.Collections.Generic;
using Core.Service;
using Core.DTO;
using Core;

namespace Core
{
    public partial class Servico
    {
        public Servico()
        {
            Dialogoservico = new HashSet<Dialogoservico>();
            Servicomaterial = new HashSet<ServicoMaterial>();
        }

        public int Id { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Descricao { get; set; }
        public int IdSolicitante { get; set; }
        public int IdTipoServico { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataAutorizacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int IdStatusServico { get; set; }
        public int IdAlmoxarife { get; set; }
        public int IdTecnico { get; set; }
        public int IdLocal { get; set; }

        public virtual Pessoa IdAlmoxarifeNavigation { get; set; }
        public virtual Local IdLocalNavigation { get; set; }
        public virtual Pessoa IdSolicitanteNavigation { get; set; }
        public virtual Statusservico IdStatusServicoNavigation { get; set; }
        public virtual Pessoa IdTecnicoNavigation { get; set; }
        public virtual TipoServico IdTipoServicoNavigation { get; set; }
        public virtual ICollection<Dialogoservico> Dialogoservico { get; set; }
        public virtual ICollection<ServicoMaterial> Servicomaterial { get; set; }
    }
}
