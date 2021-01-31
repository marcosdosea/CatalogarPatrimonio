using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IDialogoServicoService
    {
        public void Editar(DialogoServico dialogoServico);
        public int Inserir(DialogoServico dialogoServico);
        public void Remover(int idDialogoservico);
        public DialogoServico Obter(int idDialogoServico);
        public IEnumerable<DialogoServico> ObterPorNome(string mensagem);
        public IEnumerable<DialogoServico> ObterTodos();
    }
}