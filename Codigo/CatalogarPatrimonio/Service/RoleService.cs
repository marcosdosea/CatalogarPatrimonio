using Core;
using Core.Service;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class RoleService : IRoleService
    {
        private readonly CatalogarPatrimonioContext _context;

        public RoleService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public string Inserir(Aspnetroles aspnetroles)
        {
            _context.Add(aspnetroles);
            _context.SaveChanges();
            return aspnetroles.Id;
        }

        public void Editar(Aspnetroles aspnetroles)
        {
            _context.Update(aspnetroles);
            _context.SaveChanges();
        }

        public void Remover(string Id)
        {
            var _apsnetroles = _context.Aspnetroles.Find(Id);
            _context.Aspnetroles.Remove(_apsnetroles);
            _context.SaveChanges();
        }

        private IQueryable<Aspnetroles> GetQuery()
        {
            IQueryable<Aspnetroles> tb_aspnetroles = _context.Aspnetroles;
            var query = from aspnetroles in tb_aspnetroles
                        select aspnetroles;
            return query;
        }

        public IEnumerable<Aspnetroles> ObterPorNome(string Name)
        {
            IEnumerable<Aspnetroles> aspnetroles = GetQuery()
                .Where(aspnetrolesModel => aspnetrolesModel.Name.
                StartsWith(Name));
            return aspnetroles;
        }

        public IEnumerable<Aspnetroles> ObterTodos()
        {
            return GetQuery();
        }

        public Aspnetroles Obter(string Id)
        {
            IEnumerable<Aspnetroles> aspnetroles = GetQuery().Where(aspnetrolesModel => aspnetrolesModel.Id.Equals(Id));

            return aspnetroles.ElementAtOrDefault(0);
        }

        string IRoleService.Editar(Aspnetroles aspnetroles)
        {
            throw new System.NotImplementedException();
        }

        void IRoleService.Inserir(Aspnetroles aspnetroles)
        {
            throw new System.NotImplementedException();
        }
    }
}