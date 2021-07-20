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
	public class PatrimonioServiceTests
	{
		private CatalogarPatrimonioContext _context;
		private IPatrimonioService _PatrimonioService;

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
			var Patrimonio = new List<Patrimonio>
				{
					new Patrimonio { Id = 1, 
									Nome = "Museu",
									Valor = 500000,
									QrCode = "30",
									Numero = 10,
									IdTipoPatrimonio = 1,
									IdLocal = 3,
									},
					new Patrimonio { Id = 2, 
									Nome = "Teatro",
									Valor = 80000,
									QrCode = "31",
									Numero = 21,
									IdTipoPatrimonio = 1,
									IdLocal = 2,
									},
									
					new Patrimonio { Id = 3,
									Nome = "Igreja",
									Valor = 2000000,
									QrCode = "33",
									Numero = 9,
									IdTipoPatrimonio = 1,
									IdLocal = 1,
									},
				};

			_context.AddRange(Patrimonio);
			_context.SaveChanges();

			_PatrimonioService = new PatrimonioService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_PatrimonioService.Inserir(new Patrimonio() { Id = 4, Nome = "Museu" });
			// Assert
			Assert.AreEqual(4, _PatrimonioService.ObterTodos().Count());
			var Patrimonio = _PatrimonioService.Obter(2);
			Assert.AreEqual("Teatro", Patrimonio.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var Patrimonio = _PatrimonioService.Obter(3);
            Patrimonio.Nome = "UFS";
			_PatrimonioService.Editar(Patrimonio);
			Patrimonio = _PatrimonioService.Obter(3);
			Assert.AreEqual("UFS", Patrimonio.Nome);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_PatrimonioService.Remover(2);
			// Assert
			Assert.AreEqual(2, _PatrimonioService.ObterTodos().Count());
			var Patrimonio = _PatrimonioService.Obter(2);
			Assert.AreEqual(null, Patrimonio);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaPatrimonio = _PatrimonioService.ObterTodos();
            // Assert
            Assert.IsInstanceOfType(listaPatrimonio, typeof(IEnumerable<Patrimonio>));
            Assert.IsNotNull(listaPatrimonio);
            Assert.AreEqual(3, listaPatrimonio.Count());
			Assert.AreEqual(1, listaPatrimonio.First().Id);
			Assert.AreEqual("Museu", listaPatrimonio.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var Patrimonio = _PatrimonioService.Obter(2);
			Assert.IsNotNull(Patrimonio);
			Assert.AreEqual("Teatro", Patrimonio.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var Patrimonio = _PatrimonioService.ObterPorNome("Teatro");
			Assert.IsNotNull(Patrimonio);
			Assert.AreEqual(1, Patrimonio.Count());
			Assert.AreEqual("Teatro", Patrimonio.First().Nome);
		}
	}
}
