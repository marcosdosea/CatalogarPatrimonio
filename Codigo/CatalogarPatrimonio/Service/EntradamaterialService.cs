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
            return entradamaterial.IdEntrada;
        }

        public void Editar(Entradamaterial entradamaterial)
        {
            _context.Update(entradamaterial);
            _context.SaveChanges();
        }

        public void Remover(int idEntradamaterial)
        {
            var _entradamaterial = _context.Dialogoservico.Find(idEntradamaterial);
            _context.Dialogoservico.Remove(_entradamaterial);
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

        public IEnumerable<Entradamaterial> ObterTodos()
        {
            return GetQuery();
        }

        public Entradamaterial Obter(int idEntradamaterial)
        {
            IEnumerable<Entradamaterial> entradamaterial = GetQuery().Where(entradamaterialModel => entradamaterialModel.IdMaterial.Equals(idEntradamaterial));

            return entradamaterial.ElementAtOrDefault(0);
        }
    }
}
