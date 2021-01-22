using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class EmpresaService: IEmpresaService
    {
        private readonly CatalogarPatrimonioContext _context;

        public EmpresaService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Empresa empresa)
        {
            _context.Add(empresa);
            _context.SaveChanges();
            return empresa.Id;
        }

        public void Editar(Empresa empresa)
        {
            _context.Update(empresa);
            _context.SaveChanges();
        }

        public void Remover(int idEmpresa)
        {
            var _empresa = _context.Dialogoservico.Find(idEmpresa);
            _context.Dialogoservico.Remove(_empresa);
            _context.SaveChanges();
        }

        public int GetNumeroEmpresa()
        {
            return _context.Empresa.Count();
        }

        private IQueryable<Empresa> GetQuery()
        {
            IQueryable<Empresa> tb_empresa = _context.Empresa;
            var query = from empresa in tb_empresa
                        select empresa;
            return query;
        }

        public IEnumerable<Empresa> ObterPorNome(string nome)
        {
            IEnumerable<Empresa> empresa = GetQuery()
                .Where(empresaModel => empresaModel.Nome.
                StartsWith(nome));
            // seria melhor idpessoa?
            return empresa;
        }

        public IEnumerable<Empresa> ObterTodos()
        {
            return GetQuery();
        }

        public Empresa Obter(int idEmpresa)
        {
            IEnumerable<Empresa> empresa = GetQuery().Where(empresaModel => empresaModel.Id.Equals(idEmpresa));

            return empresa.ElementAtOrDefault(0);
        }
    }
}
