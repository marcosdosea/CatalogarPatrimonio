using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class PatrimonioDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int? Valor { get; set; }
        public string QrCode { get; set; }
        public int Numero { get; set; }
        public int IdTipoPAtrimonio { get; set; }
        public int IdLocal { get; set; }


    }
}
