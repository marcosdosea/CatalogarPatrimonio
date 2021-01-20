using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly CatalogarPatrimonioContext _context;

        public FornecedorService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Fornecedor fornecedor)
        {
            _context.Add(fornecedor);
            _context.SaveChanges();
            return fornecedor.Id;
        }

        public void Editar(Fornecedor fornecedor)
        {
            _context.Update(fornecedor);
            _context.SaveChanges();
        }

        public void Remover(int idFornecedor)
        {
            var _fornecedor = _context.Fornecedor.Find(idFornecedor);
            _context.Fornecedor.Remove(_fornecedor);
            _context.SaveChanges();
        }

        public int GetNumeroFornecedors()
        {
            return _context.Fornecedor.Count();
        }

        private IQueryable<Fornecedor> GetQuery()
        {
            IQueryable<Fornecedor> tb_fornecedor = _context.Fornecedor;
            var query = from fornecedor in tb_fornecedor
                        select fornecedor;
            return query;
        }

        public IEnumerable<Fornecedor> ObterPorNome(string nome)
        {
            IEnumerable<Fornecedor> fornecedors = GetQuery()
                .Where(fornecedorModel => fornecedorModel.Nome.
                StartsWith(nome));
            return fornecedors;
        }

        public IEnumerable<FornecedorDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Fornecedor> tb_fornecedor = _context.Fornecedor;
            var query = from fornecedor in tb_fornecedor
                        where nome.StartsWith(nome)
                        orderby fornecedor.Nome descending
                        select new FornecedorDTO
                        {
                            Nome = fornecedor.Nome
                        };
            return query;
        }

        public IEnumerable<Fornecedor> ObterTodos()
        {
            return GetQuery();
        }

        public Fornecedor Obter(int idFornecedor)
        {
            IEnumerable<Fornecedor> fornecedors = GetQuery().Where(fornecedorModel => fornecedorModel.Id.Equals(idFornecedor));

            return fornecedors.ElementAtOrDefault(0);
        }
    }
}
