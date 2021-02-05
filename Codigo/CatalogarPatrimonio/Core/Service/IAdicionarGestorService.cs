using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IAdicionarGestorService
    {
        int Inserir(Pessoa pessoa);
        void Remover(int idPessoa);
        public Pessoa Obter(int idPessoa);
        IEnumerable<Pessoa> ObterPorNome(string nome);
        IEnumerable<Pessoa> ObterTodos();
        IEnumerable<PessoaDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
