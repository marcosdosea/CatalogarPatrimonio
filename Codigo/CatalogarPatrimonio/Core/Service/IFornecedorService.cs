using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IFornecedorService
    {
        void Editar(Fornecedor fornecedor);
        int Inserir(Fornecedor fornecedor);
        void Remover(int idFornecedor);
        public Fornecedor Obter(int idFornecedor);
        IEnumerable<Fornecedor> ObterPorNome(string nome);
        IEnumerable<Fornecedor> ObterTodos();
        IEnumerable<FornecedorDTO> ObterPorNomeOrdenadoDescending(string nome);
    }

}
