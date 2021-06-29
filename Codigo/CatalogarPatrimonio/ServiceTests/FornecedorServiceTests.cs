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
	public class FornecedorServiceTests
	{
		private CatalogarPatrimonioContext _context;
		private IFornecedorService _FornecedorService;

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
			var Fornecedores = new List<Fornecedor>
				{
					new Fornecedor { Id = 1, Nome = "Wagner"},
					new Fornecedor { Id = 2, Nome = "Rafael"},
					new Fornecedor { Id = 3, Nome = "Daniel"},
				};

			_context.AddRange(Fornecedores);
			_context.SaveChanges();

			_FornecedorService = new FornecedorService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_FornecedorService.Inserir(new Fornecedor() { Id = 4, Nome = "Liliane" });
			// Assert
			Assert.AreEqual(4, _FornecedorService.ObterTodos().Count());
			var Fornecedor = _FornecedorService.Obter(4);
			Assert.AreEqual("Liliane", Fornecedor.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var Fornecedor = _FornecedorService.Obter(3);
			Fornecedor.Nome = "Daniel";
			_FornecedorService.Editar(Fornecedor);
			Fornecedor = _FornecedorService.Obter(3);
			Assert.AreEqual("Daniel", Fornecedor.Nome);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_FornecedorService.Remover(2);
			// Assert
			Assert.AreEqual(2, _FornecedorService.ObterTodos().Count());
			var Fornecedor = _FornecedorService.Obter(2);
			Assert.AreEqual(null, Fornecedor);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaFornecedor = _FornecedorService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaFornecedor, typeof(IEnumerable<Fornecedor>));
			Assert.IsNotNull(listaFornecedor);
			Assert.AreEqual(3, listaFornecedor.Count());
			Assert.AreEqual(1, listaFornecedor.First().Id);
			Assert.AreEqual("Wagner", listaFornecedor.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var Fornecedor = _FornecedorService.Obter(1);
			Assert.IsNotNull(Fornecedor);
			Assert.AreEqual("Wagner", Fornecedor.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var Fornecedores = _FornecedorService.ObterPorNome("Wagner");
			Assert.IsNotNull(Fornecedores);
			Assert.AreEqual(1, Fornecedores.Count());
			Assert.AreEqual("Wagner", Fornecedores.First().Nome);
		}
	}
}