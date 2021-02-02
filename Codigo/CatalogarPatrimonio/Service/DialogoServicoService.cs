using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class DialogoservicoService : IDialogoservicoService
    {
        private readonly CatalogarPatrimonioContext _context;

        public DialogoservicoService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Dialogoservico dialogoServico)
        {
            _context.Add(dialogoServico);
            _context.SaveChanges();
            return dialogoServico.Id;
        }

        public void Editar(Dialogoservico dialogoServico)
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

        private IQueryable<Dialogoservico> GetQuery()
        {
            IQueryable<Dialogoservico> tb_dialogoServico = _context.Dialogoservico;
            var query = from dialogoServico in tb_dialogoServico
                        select dialogoServico;
            return query;
        }

        public IEnumerable<Dialogoservico> ObterPorNome(string mensagem)
        {
            IEnumerable<Dialogoservico> dialogoServico = GetQuery()
                .Where(dialogoServicoModel => dialogoServicoModel.Mensagem.
                StartsWith(mensagem));
            // seria melhor idpessoa?
            return dialogoServico;
        }

        public IEnumerable<Dialogoservico> ObterTodos()
        {
            return GetQuery();
        }

        public Dialogoservico Obter(int idDialogoServico)
        {
            IEnumerable<Dialogoservico> dialogoServico = GetQuery().Where(dialogoServicoModel => dialogoServicoModel.Id.Equals(idDialogoServico));

            return dialogoServico.ElementAtOrDefault(0);
        }
    }
}
