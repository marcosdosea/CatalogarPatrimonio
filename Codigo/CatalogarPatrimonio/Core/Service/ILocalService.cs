using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface ILocalService
    {
        void Editar(Local local);
        int Inserir(Local local);
        void Remover(int idLocal);
        public Local Obter(int idLocal);
        IEnumerable<Local> ObterPorNome(string nome);
        IEnumerable<Local> ObterTodos();
        IEnumerable<LocalDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
