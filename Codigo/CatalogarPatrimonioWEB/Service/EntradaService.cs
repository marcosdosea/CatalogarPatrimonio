using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class EntradaService: IEntradaService
    {
        private readonly CatalogarPatrimonioContext _context;

        public EntradaService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(EntradaService EntradaService)
        {
            _context.Add(EntradaService);
            _context.SaveChanges();
            return EntradaService.Id;
        }

        public void Editar(EntradaService EntradaService)
        {
            _context.Update(EntradaService);
            _context.SaveChanges();
        }

        public void Remover(int idEntradaService)
        {
            var _EntradaService = _context.Dialogoservico.Find(idEntradaService);
            _context.Dialogoservico.Remove(_EntradaService);
            _context.SaveChanges();
        }

        public int GetNumeroEntrada()
        {
            return _context.Entrada.Count();
        }

        private IQueryable<EntradaService> GetQuery()
        {
            IQueryable<EntradaService> tb_EntradaService = _context.Entrada;
            var query = from EntradaService in tb_EntradaService
                        select EntradaService;
            return query;
        }

        public IEnumerable<EntradaService> ObterTodos()
        {
            return GetQuery();
        }

        public EntradaService Obter(int idEntrada)
        {
            IEnumerable<EntradaService> Entrada = GetQuery().Where(EntradaModel => EntradaModel.Id.Equals(idEntrada));

            return Entrada.ElementAtOrDefault(0);
        }
    }
}
