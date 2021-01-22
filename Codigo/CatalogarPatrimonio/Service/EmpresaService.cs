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

        public int Inserir(EmpresaService empresaservice)
        {
            _context.Add(empresaservice);
            _context.SaveChanges();
            return empresaservice.Id;
        }

        public void Editar(EmpresaService empresaservice)
        {
            _context.Update(empresaservice);
            _context.SaveChanges();
        }

        public void Remover(int idEmpresaservice)
        {
            var _empresaservice = _context.Dialogoservico.Find(idEmpresaservice);
            _context.Dialogoservico.Remove(_empresaservice);
            _context.SaveChanges();
        }

        public int GetNumeroEmpresa()
        {
            return _context.Empresa.Count();
        }

        private IQueryable<EmpresaService> GetQuery()
        {
            IQueryable<EmpresaService> tb_empresaservice = _context.Empresa;
            var query = from empresaservice in tb_empresaservice
                        select empresaservice;
            return query;
        }

        public IEnumerable<EmpresaService> ObterPorNome(string mensagem)
        {
            IEnumerable<EmpresaService> empresa = GetQuery()
                .Where(empresaModel => empresaModel.Mensagem.
                StartsWith(mensagem));
            // seria melhor idpessoa?
            return empresa;
        }

        public IEnumerable<EmpresaService> ObterTodos()
        {
            return GetQuery();
        }

        public EmpresaService Obter(int idEmpresa)
        {
            IEnumerable<EmpresaService> empresa = GetQuery().Where(empresaModel => empresaModel.Id.Equals(idEmpresa));

            return empresa.ElementAtOrDefault(0);
        }
    }
}
