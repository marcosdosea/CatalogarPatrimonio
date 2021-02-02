using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class EntradamaterialService : IEntradamaterialService
    {
        private readonly CatalogarPatrimonioContext _context;

        public EntradamaterialService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Entradamaterial entradamaterial)
        {
            _context.Add(entradamaterial);
            _context.SaveChanges();
            return entradamaterial.Id;
        }

        public void Editar(Entradamaterial entradamaterial)
        {
            _context.Update(entradamaterial);
            _context.SaveChanges();
        }

        public void Remover(int idEntradamaterial)
        {
            var _entradamaterial = _context.Entradamaterial.Find(idEntradamaterial);
            _context.Entradamaterial.Remove(_entradamaterial);
            _context.SaveChanges();
        }

        public int GetNumeroEntradamaterial()
        {
            return _context.Entradamaterial.Count();
        }

        private IQueryable<Entradamaterial> GetQuery()
        {
            IQueryable<Entradamaterial> tb_entradamaterial = _context.Entradamaterial;
            var query = from entradamaterial in tb_entradamaterial
                        select entradamaterial;
            return query;
        }

        public IEnumerable<Entradamaterial> ObterPorNome(string nome)
        {
            IEnumerable<Entradamaterial> entradamaterial = GetQuery()
                .Where(entradamaterialModel => entradamaterialModel.Nome.
                StartsWith(nome));
            return entradamaterial;
        }

        public IEnumerable<EntradamaterialDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Entradamaterial> tb_entradamaterial = _context.Entradamaterial;
            var query = from entradamaterial in tb_entradamaterial
                        where nome.StartsWith(nome)
                        orderby entradamaterial.Nome descending
                        select new EntradamaterialDTO
                        {
                            nome = entradamaterial.Nome
                        };
            return query;
        }

        public IEnumerable<Entradamaterial> ObterTodos()
        {
            return GetQuery();
        }

        public Entradamaterial Obter(int idEntradamaterial)
        {
            IEnumerable<Entradamaterial> entradamaterial = GetQuery().Where(entradamaterialModel => entradamaterialModel.Id.Equals(idEntradamaterial));

            return entradamaterial.ElementAtOrDefault(0);
        }
    }
}
