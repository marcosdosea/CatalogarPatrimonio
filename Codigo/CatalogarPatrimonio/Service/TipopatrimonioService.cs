using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class TipopatrimonioService: ITipopatrimonioService
    {
        private readonly CatalogarPatrimonioContext _context;

        public TipopatrimonioService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Tipopatrimonio tipoPatrimonio)
        {
            _context.Add(tipoPatrimonio);
            _context.SaveChanges();
            return tipoPatrimonio.Id;
        }

        public void Editar(Tipopatrimonio tipoPatrimonio)
        {
            _context.Update(tipoPatrimonio);
            _context.SaveChanges();
        }

        public void Remover(int idTipopatrimonio)
        {
            var _tipoPatrimonio = _context.Tipopatrimonio.Find(idTipopatrimonio);
            _context.Tipopatrimonio.Remove(_tipoPatrimonio);
            _context.SaveChanges();
        }

        public int GetNumeroTipopatrimonio()
        {
            return _context.Tipopatrimonio.Count();
        }

        private IQueryable<Tipopatrimonio> GetQuery()
        {
            IQueryable<Tipopatrimonio> tb_tipoPatrimonio = _context.Tipopatrimonio;
            var query = from tipoPatrimonio in tb_tipoPatrimonio
                        select tipoPatrimonio;
            return query;
        }

        public IEnumerable<Tipopatrimonio> ObterPorNome(string nome)
        {
            IEnumerable<Tipopatrimonio> tipoPatrimonio = GetQuery()
                .Where(tipoPatrimonioModel => tipoPatrimonioModel.Nome.
                StartsWith(nome));
            return tipoPatrimonio;
        }

        public IEnumerable<Tipopatrimonio> ObterTodos()
        {
            return GetQuery();
        }

        public Tipopatrimonio Obter(int idTipopatrimonio)
        {
            IEnumerable<Tipopatrimonio> tipoPatrimonio = GetQuery().Where(tipoPatrimonioModel => tipoPatrimonioModel.Id.Equals(idTipopatrimonio));

            return tipoPatrimonio.ElementAtOrDefault(0);
        }
    }
}
