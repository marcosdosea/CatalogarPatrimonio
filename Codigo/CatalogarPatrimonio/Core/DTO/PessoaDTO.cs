using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class PessoaDTO
    {
        public int Id { get; set; }
		public string nome { get; set; }
        public DateTime? dataNascimento { get; set; }
        public string CPF { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string senha { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public int idEmpresa { get; set;}
        public string tipo { get; set; }
    }
}
