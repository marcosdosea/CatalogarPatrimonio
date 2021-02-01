using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IPredioService
    {
        public void Editar(Predio predio);
        public int Inserir(Predio predio);
        public void Remover(int idPredio);
        public Predio Obter(int idPredio);
        public IEnumerable<Predio> ObterPorNome(string mensagem);
        public IEnumerable<Predio> ObterTodos();
    }
}
