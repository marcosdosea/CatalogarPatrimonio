using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class ServicoService : IServicoService
    {
        private readonly CatalogarPatrimonioContext _context;
        public ServicoService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }
        public int Inserir(Servico servico)
        {
            _context.Add(servico);
            _context.SaveChanges();
            return servico.Id;
        }
        public void Editar(Servico servico)
        {
            _context.Update(servico);
            _context.SaveChanges();
        }
        public void Remover(int idServico)
        {
            var _servico = _context.Servico.Find(idServico);
            _context.Servico.Remove(_servico);
            _context.SaveChanges();
        }
        public int GetNumeroServicos()
        {
            return _context.Servico.Count();
        }
        private IQueryable<Servico> GetQuery()
        {
            IQueryable<Servico> tb_servico = _context.Servico;
            var query = from servico in tb_servico 
                        select servico;
            return query;
        }
        public IEnumerable<Servico> ObterPorData(string descricao)
        {
            IEnumerable<Servico> servicos = GetQuery()
                .Where(servicoModel => servicoModel.Descricao.
                StartsWith(descricao));
            return servicos;
        }
        public IEnumerable<Servico> ObterPorDataOrdenadoDescending(string descricao)
        {
            IQueryable<Servico> tb_servico = _context.Servico;
            var query = from servico in tb_servico
                        where descricao.StartsWith(descricao)
                        orderby servico.DataSolicitacao descending
                        select new Servico
                        {
                            Descricao = servico.Descricao
                        };
            return query;
        }
        public IEnumerable<Servico> ObterTodos()
        {
            return GetQuery();
        }
        public Servico Obter(int idServico)
        {
            IEnumerable<Servico> servicos = GetQuery().Where(servicoModel => servicoModel.Id.Equals(idServico));
            return servicos.ElementAtOrDefault(0);
        }
    }
}
