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

        public int Inserir(Entrada entrada)
        {
            _context.Add(entrada);
            _context.SaveChanges();
            return entrada.Id;
        }

        public void Editar(Entrada entrada)
        {
            _context.Update(entrada);
            _context.SaveChanges();
        }

        public void Remover(int idEntrada)
        {
            var _entrada = _context.Dialogoservico.Find(idEntrada);
            _context.Dialogoservico.Remove(_entrada);
            _context.SaveChanges();
        }

        public int GetNumeroEntrada()
        {
            return _context.Entrada.Count();
        }

        private IQueryable<Entrada> GetQuery()
        {
            IQueryable<Entrada> tb_EntradaService = _context.Entrada;
            var query = from EntradaService in tb_EntradaService
                        select EntradaService;
            return query;
        }

        public IEnumerable<Entrada> ObterTodos()
        {
            return GetQuery();
        }

        public Entrada Obter(int idEntrada)
        {
            IEnumerable<Entrada> entrada = GetQuery().Where(EntradaModel => EntradaModel.Id.Equals(idEntrada));

            return entrada.ElementAtOrDefault(0);
        }
    }
}
