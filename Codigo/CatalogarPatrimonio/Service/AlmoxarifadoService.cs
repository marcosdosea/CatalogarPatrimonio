using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Service;
using Core.DTO;

namespace Service
{
    public class AlmoxarifadoService : IAlmoxarifadoService
    {
        private readonly CatalogarPatrimonioContext _context;

        public AlmoxarifadoService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Almoxarifado almoxarifado)
        {
            _context.Add(almoxarifado);
            _context.SaveChanges();
            return almoxarifado.Id;
        }

        public void Editar(Almoxarifado almoxarifado)
        {
            _context.Update(almoxarifado);
            _context.SaveChanges();
        }

        public void Remover(int idAlmoxarifado)
        {
            var _almoxarifado= _context.Almoxarifado.Find(idAlmoxarifado);
            _context.Almoxarifado.Remove(_almoxarifado);
            _context.SaveChanges();
        }

        public int GetNumeroAlmoxarifados()
        {
            return _context.Almoxarifado.Count();
        }

        private IQueryable<Almoxarifado> GetQuery()
        {
            IQueryable<Almoxarifado> tb_almoxarifado = _context.Almoxarifado;
            var query = from Almoxarifado in tb_almoxarifado
                        select Almoxarifado;
            return query;
        }

        public IEnumerable<Almoxarifado> ObterPorNome(string nome)
        {
            IEnumerable<Almoxarifado> almoxarifados = GetQuery()
                .Where(almoxarifadoModel => almoxarifadoModel.Nome.
                StartsWith(nome));
            return almoxarifados;
        }

        public IEnumerable<AlmoxarifadoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Almoxarifado> tb_almoxarifado = _context.Almoxarifado;
            var query = from almoxarifado in tb_almoxarifado
                        where nome.StartsWith(nome)
                        orderby almoxarifado.Nome descending
                        select new AlmoxarifadoDTO
                        {
                            Nome = almoxarifado.Nome
                        };
            return query;
        }

        public IEnumerable<Almoxarifado> ObterTodos()
        {
            return GetQuery();
        }

        public Almoxarifado Obter(int idAlmoxarifado)
        {
            IEnumerable<Almoxarifado> almoxarifados = GetQuery().Where(almoxarifadoModel => almoxarifadoModel.Id.Equals(idAlmoxarifado));

            return almoxarifados.ElementAtOrDefault(0);
        }
    }
}
