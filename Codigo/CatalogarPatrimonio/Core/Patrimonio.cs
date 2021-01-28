﻿using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Patrimonio
    {
        public Patrimonio()
        {
            ServicoMaterial = new HashSet<ServicoMaterial>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal? Valor { get; set; }
        public string QrCode { get; set; }
        public int? Numero { get; set; }
        public int IdTipoPatrimonio { get; set; }
        public int IdLocal { get; set; }

        public virtual Local IdLocalNavigation { get; set; }
        public virtual TipoPatrimonio IdTipoPatrimonioNavigation { get; set; }
        public virtual ICollection<ServicoMaterial> ServicoMaterial { get; set; }
    }
}
