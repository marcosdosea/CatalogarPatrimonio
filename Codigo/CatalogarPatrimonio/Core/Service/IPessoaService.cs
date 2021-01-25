using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IPessoaService
    {
        public void Editar(Pessoa pessoa);
        public int Inserir(Pessoa pessoa);
        public void Remover(int idPessoa);
        public Pessoa Obter(int idPessoa);
        public IEnumerable<Pessoa> ObterPorNome(string nome);
        public IEnumerable<Pessoa> ObterTodos();
    }
}
