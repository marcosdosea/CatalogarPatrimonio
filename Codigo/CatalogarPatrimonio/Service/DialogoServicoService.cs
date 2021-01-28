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

        public int Inserir(DialogoServico dialogoservico)
        {
            _context.Add(dialogoservico);
            _context.SaveChanges();
            return dialogoservico.Id;
        }

        public void Editar(DialogoServico dialogoservico)
        {
            _context.Update(dialogoservico);
            _context.SaveChanges();
        }

        public void Remover(int idDialogoservico)
        {
            var _dialogoservico = _context.DialogoServico.Find(idDialogoservico);
            _context.DialogoServico.Remove(_dialogoservico);
            _context.SaveChanges();
        }

        public int GetNumeroDialogo()
        {
            return _context.DialogoServico.Count();
        }

        private IQueryable<DialogoServico> GetQuery()
        {
            IQueryable<DialogoServico> tb_dialogoservico = _context.DialogoServico;
            var query = from dialogoservico in tb_dialogoservico
                        select dialogoservico;
            return query;
        }

        public IEnumerable<DialogoServico> ObterPorNome(string mensagem)
        {
            IEnumerable<DialogoServico> dialogoservico = GetQuery()
                .Where(dialogoservicoModel => dialogoservicoModel.Mensagem.
                StartsWith(mensagem));
            // seria melhor idpessoa?
            return dialogoservico;
        }

        public IEnumerable<DialogoServico> ObterTodos()
        {
            return GetQuery();
        }

        public DialogoServico Obter(int idDialogoservico)
        {
            IEnumerable<DialogoServico> dialogoservico = GetQuery().Where(dialogoservicoModel => dialogoservicoModel.Id.Equals(idDialogoservico));

            return dialogoservico.ElementAtOrDefault(0);
        }
    }
}
