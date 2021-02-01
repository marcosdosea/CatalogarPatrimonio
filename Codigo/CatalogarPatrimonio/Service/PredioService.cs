using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class PredioService : IPredioService
    {
        private readonly CatalogarPatrimonioContext _context;

        public PredioService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Predio predio)
        {
            _context.Add(predio);
            _context.SaveChanges();
            return predio.Id;
        }

        public void Editar(Predio predio)
        {
            _context.Update(predio);
            _context.SaveChanges();
        }

        public void Remover(int idPredio)
        {
            var _predio = _context.Predio.Find(idPredio);
            _context.Predio.Remove(_predio);
            _context.SaveChanges();
        }

        public int GetNumeroPredio()
        {
            return _context.Predio.Count();
        }

        private IQueryable<Predio> GetQuery()
        {
            IQueryable<Predio> tb_predio = _context.Predio;
            var query = from predio in tb_predio
                        select predio;
            return query;
        }

        public IEnumerable<Predio> ObterPorNome(string nome)
        {
            IEnumerable<Predio> predio = GetQuery()
                .Where(predioModel => predioModel.Nome.
                StartsWith(nome));
            // seria melhor idpessoa?
            return predio;
        }

        public IEnumerable<Predio> ObterTodos()
        {
            return GetQuery();
        }

        public Predio Obter(int idPredio)
        {
            IEnumerable<Predio> predio = GetQuery().Where(predioModel => predioModel.Id.Equals(idPredio));

            return predio.ElementAtOrDefault(0);
        }
    }
}