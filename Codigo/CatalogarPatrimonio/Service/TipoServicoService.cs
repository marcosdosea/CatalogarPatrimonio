using Core;
using Core.DTO;
using Core.Service;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class TiposervicoService : ITiposervicoService
    {
        private readonly CatalogarPatrimonioContext _context;

        public TiposervicoService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Tiposervico tiposervico)
        {
            _context.Add(tiposervico);
            _context.SaveChanges();
            return tiposervico.Id;
        }

        public void Editar(Tiposervico tiposervico)
        {
            _context.Update(tiposervico);
            _context.SaveChanges();
        }

        public void Remover(int idTiposervico)
        {
            var _tiposervico = _context.Tiposervico.Find(idTiposervico);
            _context.Tiposervico.Remove(_tiposervico);
            _context.SaveChanges();
        }

        public int GetNumeroTiposervico()
        {
            return _context.Tiposervico.Count();
        }

        private IQueryable<Tiposervico> GetQuery()
        {
            IQueryable<Tiposervico> tb_tiposervico = _context.Tiposervico;
            var query = from tiposervico in tb_tiposervico
                        select tiposervico;
            return query;
        }

        public IEnumerable<Tiposervico> ObterPorNome(string nome)
        {
            IEnumerable<Tiposervico> tiposervico= GetQuery()
                .Where(tiposervicoModel => tiposervicoModel.Nome.
                StartsWith(nome));
            return tiposervico;
        }

        public IEnumerable<TiposervicoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Tiposervico> tb_tiposervico = _context.Tiposervico;
            var query = from tiposervico in tb_tiposervico
                        where nome.StartsWith(nome)
                        orderby tiposervico.Nome descending
                        select new TiposervicoDTO
                        {
                            Nome = tiposervico.Nome
                        };
            return query;
        }

        public IEnumerable<Tiposervico> ObterTodos()
        {
            return GetQuery();
        }

        public Tiposervico Obter(int idTiposervico)
        {
            IEnumerable<Tiposervico> tiposervico = GetQuery().Where(tiposervicoModel => tiposervicoModel.Id.Equals(idTiposervico));

            return tiposervico.ElementAtOrDefault(0);
        }
    }
}
