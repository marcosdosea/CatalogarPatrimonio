using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class DialogoserviceService :IDialogoservicoService
    {
        private readonly CatalogarPatrimonioContext _context;

        public DialogoserviceService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(DialogoservicoService dialogoservico)
        {
            _context.Add(dialogoservico);
            _context.SaveChanges();
            return dialogoservico.Id;
        }

        public void Editar(DialogoservicoService dialogoservico)
        {
            _context.Update(dialogoservico);
            _context.SaveChanges();
        }

        public void Remover(int idDialogoservico)
        {
            var _dialogoservico = _context.Dialogoservico.Find(idDialogoservico);
            _context.Dialogoservico.Remove(_dialogoservico);
            _context.SaveChanges();
        }

        public int GetNumeroAlmoxarifados()
        {
            return _context.Dialogoservico.Count();
        }

        private IQueryable<DialogoservicoService> GetQuery()
        {
            IQueryable<DialogoservicoService> tb_dialogoservico = _context.Dialogoservico;
            var query = from dialogoservico in tb_dialogoservico
                        select dialogoservico;
            return query;
        }

        public IEnumerable<DialogoservicoService> ObterPorNome(string mensagem)
        {
            IEnumerable<DialogoservicoService> dialogoservico = GetQuery()
                .Where(dialogoservicoModel => dialogoservicoModel.Mensagem.
                StartsWith(mensagem));
            // seria melhor idpessoa?
            return dialogoservico;
        }

        public IEnumerable<DialogoservicoService> ObterTodos()
        {
            return GetQuery();
        }

        public DialogoservicoService Obter(int idDialogoservico)
        {
            IEnumerable<DialogoservicoService> dialogoservico = GetQuery().Where(dialogoservicoModel => dialogoservicoModel.Id.Equals(idDialogoservico));

            return dialogoservico.ElementAtOrDefault(0);
        }
    }
}
