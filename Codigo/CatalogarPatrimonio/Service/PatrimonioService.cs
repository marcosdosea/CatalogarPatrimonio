using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Service;
using Core.DTO;

namespace Service
{
    public class PatrimonioService : IPatrimonioService
    {
        private readonly CatalogarPatrimonioContext _context; 

        public PatrimonioService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Patrimonio patrimonio)
        {
            _context.Add(patrimonio);
            _context.SaveChanges();
            return patrimonio.Id;
        }

        public void Editar(Patrimonio patrimonio)
        {
            _context.Update(patrimonio);
            _context.SaveChanges();
        }

        public void Remover(int idPatrimonio)
        {
            var _patrimonio= _context.Patrimonio.Find(idPatrimonio);
            _context.Patrimonio.Remove(_patrimonio);
            _context.SaveChanges();
        }

        public int GetNumeroPatrimonios()
        {
            return _context.Patrimonio.Count();
        }

        private IQueryable<Patrimonio> GetQuery()
        {
            IQueryable<Patrimonio> tb_patrimonio = _context.Patrimonio;
            var query = from Patrimonio in tb_patrimonio
                        select Patrimonio;
            return query;
        }

        public IEnumerable<Patrimonio> ObterPorNome(string nome)
        {
            IEnumerable<Patrimonio> patrimonios = GetQuery()
                .Where(patrimonioModel => patrimonioModel.Nome.
                StartsWith(nome));
            return patrimonios;
        }

        public IEnumerable<PatrimonioDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Patrimonio> tb_patrimonio = _context.Patrimonio;
            var query = from patrimonio in tb_patrimonio
                        where nome.StartsWith(nome)
                        orderby patrimonio.Nome descending
                        select new PatrimonioDTO
                        {
                            Nome = patrimonio.Nome
                        };
            return query;
        }

        public IEnumerable<Patrimonio> ObterTodos()
        {
            return GetQuery();
        }

        public Patrimonio Obter(int idPatrimonio)
        {
            IEnumerable<Patrimonio> patrimonios = GetQuery().Where(patrimonioModel => patrimonioModel.Id.Equals(idPatrimonio));

            return patrimonios.ElementAtOrDefault(0);
        }
    }
}
