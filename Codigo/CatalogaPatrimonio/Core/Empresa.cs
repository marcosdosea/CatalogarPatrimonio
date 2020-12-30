using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Empresa
    {
        public Empresa()
        {
            Almoxarifado = new HashSet<Almoxarifado>();
            Pessoa = new HashSet<Pessoa>();
            Predio = new HashSet<Predio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Almoxarifado> Almoxarifado { get; set; }
        public virtual ICollection<Pessoa> Pessoa { get; set; }
        public virtual ICollection<Predio> Predio { get; set; }
    }
}
