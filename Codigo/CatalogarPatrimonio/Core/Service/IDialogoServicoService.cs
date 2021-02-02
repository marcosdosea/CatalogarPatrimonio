using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IDialogoservicoService
    {
        public void Editar(Dialogoservico dialogoServico);
        public int Inserir(Dialogoservico dialogoServico);
        public void Remover(int idDialogoservico);
        public Dialogoservico Obter(int idDialogoServico);
        public IEnumerable<Dialogoservico> ObterPorNome(string mensagem);
        public IEnumerable<Dialogoservico> ObterTodos();
    }
}