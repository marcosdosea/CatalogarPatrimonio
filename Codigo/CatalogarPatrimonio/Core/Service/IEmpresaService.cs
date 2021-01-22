using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IEmpresaService
    {
        public void Editar(Empresa empresa);
        public int Inserir(Empresa empresa);
        public void Remover(int idEmpresa);
        public Empresa Obter(int idEmpresa);
        public IEnumerable<Empresa> ObterPorNome(string mensagem);
        public IEnumerable<Empresa> ObterTodos();
    }
}
