using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
	[TestClass()]
	public class PessoaServiceTests
	{
		private CatalogarPatrimonioContext _context;
		private IPessoaService _PessoaService;

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			var builder = new DbContextOptionsBuilder<CatalogarPatrimonioContext>();
			builder.UseInMemoryDatabase("CatalogarPatrimonio");
			var options = builder.Options;

			_context = new CatalogarPatrimonioContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var Pessoaes = new List<Pessoa>
				{
					new Pessoa { 
						Id = 1,
						Nome = "Daniel Santos",
						DataNascimento = new DateTime(1997, 11, 06, 0, 0, 0),
						Cpf = "06497631577",
						Email = "daniel17sants@gmail.com",
						Telefone = "79999655134",
						Tipo = "Administrador"
					},
					new Pessoa { 
						Id = 2,
						Nome = "Rafael Silveira",
						DataNascimento = new DateTime(1997, 11, 06, 0, 0, 0),
						Cpf = "06497631577",
						Email = "daniel17sants@gmail.com",
						Telefone = "79999655134",
						Tipo = "Administrador"
					},
					new Pessoa {
						Id = 3,
						Nome = "Wagner Prata",
						DataNascimento = new DateTime(1997, 11, 06, 0, 0, 0),
						Cpf = "06497631577",
						Email = "daniel17sants@gmail.com",
						Telefone = "79999655134",
						Tipo = "Administrador"
					},
				};

			_context.AddRange(Pessoaes);
			_context.SaveChanges();

			_PessoaService = new PessoaService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_PessoaService.Inserir(new Pessoa() { Id = 4, Nome = "José Carlos" });
			// Assert
			Assert.AreEqual(4, _PessoaService.ObterTodos().Count());
			var Pessoa = _PessoaService.Obter(4);
			Assert.AreEqual("José Carlos", Pessoa.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var Pessoa = _PessoaService.Obter(3);
			Pessoa.Nome = "Samara Oliveira";
			_PessoaService.Editar(Pessoa);
			Pessoa = _PessoaService.Obter(3);
			Assert.AreEqual("Samara Oliveira", Pessoa.Nome);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_PessoaService.Remover(2);
			// Assert
			Assert.AreEqual(2, _PessoaService.ObterTodos().Count());
			var Pessoa = _PessoaService.Obter(2);
			Assert.AreEqual(null, Pessoa);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaPessoa = _PessoaService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaPessoa, typeof(IEnumerable<Pessoa>));
			Assert.IsNotNull(listaPessoa);
			Assert.AreEqual(3, listaPessoa.Count());
			Assert.AreEqual(1, listaPessoa.First().Id);
			Assert.AreEqual("Daniel Santos", listaPessoa.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var Pessoa = _PessoaService.Obter(1);
			Assert.IsNotNull(Pessoa);
			Assert.AreEqual("Daniel Santos", Pessoa.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var Pessoaes = _PessoaService.ObterPorNome("Daniel Santos");
			Assert.IsNotNull(Pessoaes);
			Assert.AreEqual(1, Pessoaes.Count());
			Assert.AreEqual("Daniel Santos", Pessoaes.First().Nome);
		}
	}
}