using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class DialogoServicoService :IDialogoServicoService
    {
        private readonly CatalogarPatrimonioContext _context;

        public DialogoServicoService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(DialogoServico dialogoServico)
        {
            _context.Add(dialogoServico);
            _context.SaveChanges();
            return dialogoServico.Id;
        }

        public void Editar(DialogoServico dialogoServico)
        {
            _context.Update(dialogoServico);
            _context.SaveChanges();
        }

        public void Remover(int idDialogoServico)
        {
            var _dialogoServico = _context.Dialogoservico.Find(idDialogoServico);
            _context.Dialogoservico.Remove(_dialogoServico);
            _context.SaveChanges();
        }

        public int GetNumeroDialogo()
        {
            return _context.Dialogoservico.Count();
        }

        private IQueryable<DialogoServico> GetQuery()
        {
            IQueryable<DialogoServico> tb_dialogoServico = _context.Dialogoservico;
            var query = from dialogoServico in tb_dialogoServico
                        select dialogoServico;
            return query;
        }

        public IEnumerable<DialogoServico> ObterPorNome(string mensagem)
        {
            IEnumerable<DialogoServico> dialogoServico = GetQuery()
                .Where(dialogoServicoModel => dialogoServicoModel.Mensagem.
                StartsWith(mensagem));
            // seria melhor idpessoa?
            return dialogoServico;
        }

        public IEnumerable<DialogoServico> ObterTodos()
        {
            return GetQuery();
        }

        public DialogoServico Obter(int idDialogoServico)
        {
            IEnumerable<DialogoServico> dialogoServico = GetQuery().Where(dialogoServicoModel => dialogoServicoModel.Id.Equals(idDialogoServico));

            return dialogoServico.ElementAtOrDefault(0);
        }
    }
}
