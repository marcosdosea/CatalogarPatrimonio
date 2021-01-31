using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class TipoServicoService : ITipoServicoService
    {
        private readonly CatalogarPatrimonioContext _context;

        public TipoServicoService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(TipoServico tiposervico)
        {
            _context.Add(tiposervico);
            _context.SaveChanges();
            return tiposervico.Id;
        }

        public void Editar(TipoServico tiposervico)
        {
            _context.Update(tiposervico);
            _context.SaveChanges();
        }

        public void Remover(int idTipoServico)
        {
            var _tiposervico = _context.TipoServico.Find(idTipoServico);
            _context.TipoServico.Remove(_tiposervico);
            _context.SaveChanges();
        }

        public int GetNumeroTipoServico()
        {
            return _context.TipoServico.Count();
        }

        private IQueryable<TipoServico> GetQuery()
        {
            IQueryable<TipoServico> tb_tiposervico = _context.TipoServico;
            var query = from tiposervico in tb_tiposervico
                        select tiposervico;
            return query;
        }

        public IEnumerable<TipoServico> ObterPorNome(string nome)
        {
            IEnumerable<TipoServico> tiposervico= GetQuery()
                .Where(tiposervicoModel => tiposervicoModel.Nome.
                StartsWith(nome));
            return tiposervico;
        }

        public IEnumerable<TipoServicoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<TipoServico> tb_tiposervico = _context.TipoServico;
            var query = from tiposervico in tb_tiposervico
                        where nome.StartsWith(nome)
                        orderby tiposervico.Nome descending
                        select new TipoServicoDTO
                        {
                            Nome = tiposervico.Nome
                        };
            return query;
        }

        public IEnumerable<TipoServico> ObterTodos()
        {
            return GetQuery();
        }

        public TipoServico Obter(int idTipoServico)
        {
            IEnumerable<TipoServico> tiposervico = GetQuery().Where(tiposervicoModel => tiposervicoModel.Id.Equals(idTipoServico));

            return tiposervico.ElementAtOrDefault(0);
        }
    }
}
