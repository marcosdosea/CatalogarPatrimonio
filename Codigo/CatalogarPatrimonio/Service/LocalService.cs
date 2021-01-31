using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class LocalService : ILocalService
    {
        private readonly CatalogarPatrimonioContext _context;

        public LocalService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Local local)
        {
            _context.Add(local);
            _context.SaveChanges();
            return local.Id;
        }

        public void Editar(Local local)
        {
            _context.Update(local);
            _context.SaveChanges();
        }

        public void Remover(int idLocal)
        {
            var _local = _context.Local.Find(idLocal);
            _context.Local.Remove(_local);
            _context.SaveChanges();
        }

        public int GetNumeroLocals()
        {
            return _context.Local.Count();
        }

        private IQueryable<Local> GetQuery()
        {
            IQueryable<Local> tb_local = _context.Local;
            var query = from local in tb_local
                        select local;
            return query;
        }

        public IEnumerable<Local> ObterPorNome(string nome)
        {
            IEnumerable<Local> locais = GetQuery()
                .Where(localModel => localModel.Nome.
                StartsWith(nome));
            return locais;
        }

        public IEnumerable<LocalDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Local> tb_local = _context.Local;
            var query = from local in tb_local
                        where nome.StartsWith(nome)
                        orderby local.Nome descending
                        select new LocalDTO
                        {
                            Nome = local.Nome
                        };
            return query;
        }

        public IEnumerable<Local> ObterTodos()
        {
            return GetQuery();
        }

        public Local Obter(int idLocal)
        {
            IEnumerable<Local> locais = GetQuery().Where(localModel => localModel.Id.Equals(idLocal));

            return locais.ElementAtOrDefault(0);
        }
    }
}
