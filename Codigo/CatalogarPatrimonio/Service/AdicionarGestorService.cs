using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Service;
using Core.DTO;

namespace Service
{
    public class AdicionarGestorService : IAdicionarGestorService
    {
        private readonly CatalogarPatrimonioContext _context;

        public AdicionarGestorService(CatalogarPatrimonioContext context)
        {
            _context = context;
        }

        public int Inserir(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
            return pessoa.Id;
        }

        public void Editar(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
        }

        public void Remover(int idPessoa)
        {
            var _pessoa= _context.Pessoa.Find(idPessoa);
            _context.Pessoa.Remove(_pessoa);
            _context.SaveChanges();
        }

        public int GetNumeroPessoas()
        {
            return _context.Pessoa.Count();
        }

        private IQueryable<Pessoa> GetQuery()
        {
            IQueryable<Pessoa> tb_pessoa = _context.Pessoa;
            var query = from Pessoa in tb_pessoa
                        select Pessoa;
            return query;
        }

        public IEnumerable<Pessoa> ObterPorNome(string nome)
        {
            IEnumerable<Pessoa> pessoas = GetQuery()
                .Where(pessoaModel => pessoaModel.Nome.
                StartsWith(nome));
            return pessoas;
        }

        public IEnumerable<PessoaDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Pessoa> tb_pessoa = _context.Pessoa;
            var query = from pessoa in tb_pessoa
                        where nome.StartsWith(nome)
                        orderby pessoa.Nome descending
                        select new PessoaDTO
                        {
                            nome = pessoa.Nome
                        };
            return query;
        }

        public IEnumerable<Pessoa> ObterTodos()
        {
            return GetQuery();
        }

        public Pessoa Obter(int idPessoa)
        {
            IEnumerable<Pessoa> pessoas = GetQuery().Where(pessoaModel => pessoaModel.Id.Equals(idPessoa));

            return pessoas.ElementAtOrDefault(0);
        }
    }
}
