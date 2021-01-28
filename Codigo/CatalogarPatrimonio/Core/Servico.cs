﻿using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Servico
    {
        public Servico()
        {
            DialogoServico = new HashSet<DialogoServico>();
            ServicoMaterial = new HashSet<ServicoMaterial>();
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
        public virtual StatusServico IdStatusServicoNavigation { get; set; }
        public virtual Pessoa IdTecnicoNavigation { get; set; }
        public virtual TipoServico IdTipoServicoNavigation { get; set; }
        public virtual ICollection<DialogoServico> DialogoServico { get; set; }
        public virtual ICollection<ServicoMaterial> ServicoMaterial { get; set; }
    }
}
