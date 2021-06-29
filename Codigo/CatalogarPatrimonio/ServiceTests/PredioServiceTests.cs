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
	public class PredioServiceTests
	{
		private CatalogarPatrimonioContext _context;
		private IPredioService _PredioService;

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
			var Predio = new List<Predio>
				{
					new Predio { Id = 1, Nome = "Elétrico"},
					new Predio { Id = 2, Nome = "Eletrônico"},
					new Predio { Id = 3, Nome = "Monumento"},
				};

			_context.AddRange(Predio);
			_context.SaveChanges();

			_PredioService = new PredioService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_PredioService.Inserir(new Predio() { Id = 4, Nome = "Refrigeração" });
			// Assert
			Assert.AreEqual(4, _PredioService.ObterTodos().Count());
			var Predio = _PredioService.Obter(4);
			Assert.AreEqual("Refrigeração", Predio.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var Predio = _PredioService.Obter(3);
			Predio.Nome = "Carpintaria";
			_PredioService.Editar(Predio);
			Predio = _PredioService.Obter(3);
			Assert.AreEqual("Carpintaria", Predio.Nome);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_PredioService.Remover(2);
			// Assert
			Assert.AreEqual(2, _PredioService.ObterTodos().Count());
			var Predio = _PredioService.Obter(2);
			Assert.AreEqual(null, Predio);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaPredio = _PredioService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaPredio, typeof(IEnumerable<Predio>));
			Assert.IsNotNull(listaPredio);
			Assert.AreEqual(3, listaPredio.Count());
			Assert.AreEqual(1, listaPredio.First().Id);
			Assert.AreEqual("Elétrico", listaPredio.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var Predio = _PredioService.Obter(1);
			Assert.IsNotNull(Predio);
			Assert.AreEqual("Elétrico", Predio.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var TipoPredio = _PredioService.ObterPorNome("Elétrico");
			Assert.IsNotNull(TipoPredio);
			Assert.AreEqual(1, TipoPredio.Count());
			Assert.AreEqual("Elétrico", TipoPredio.First().Nome);
		}
	}
}