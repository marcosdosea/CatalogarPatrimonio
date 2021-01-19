using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IEmpresaService
    {
        public void Editar(EmpresaService empresaservice);
        public int Inserir(EmpresaService empresaservice);
        public void Remover(int idEmpresaservico);
        public EmpresaService Obter(int idDialogoservico);
        public IEnumerable<EmpresaService> ObterPorNome(string mensagem);
        public IEnumerable<EmpresaService> ObterTodos();
    }
}
