using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IDialogoservicoService
    {
        public void Editar(DialogoservicoService dialogoservico);
        public int Inserir(DialogoservicoService dialogoservico);
        public void Remover(int idDialogoservico);
        public DialogoservicoService Obter(int idDialogoservico);
        public IEnumerable<DialogoservicoService> ObterPorNome(string mensagem);
        public IEnumerable<DialogoservicoService> ObterTodos();
    }
}