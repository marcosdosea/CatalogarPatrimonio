using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal? Valor { get; set; }
        public int IdTipoMAterial { get; set; }
        public int DeveVincularMaterial { get; set; }
        public int StatusSolicitacao { get; set; }
    }
}
