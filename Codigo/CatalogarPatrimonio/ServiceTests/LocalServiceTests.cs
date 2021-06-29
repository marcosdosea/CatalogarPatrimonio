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
	public class LocalServiceTests
	{
		private CatalogarPatrimonioContext _context;
		private ILocalService _LocalService;
        private object listaLocal;

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
			var Local = new List<Local>
				{
					new Local { Id = 1, Nome = "Predipo"},
					new Local { Id = 2, Nome = "Casa"},
					new Local { Id = 3, Nome = "Empresa"},
				};

			_context.AddRange(Local);
			_context.SaveChanges();

			_LocalService = new LocalService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_LocalService.Inserir(new Local() { Id = 4, Nome = "Predio" });
			// Assert
			Assert.AreEqual(4, _LocalService.ObterTodos().Count());
			var Local = _LocalService.Obter(4);
			Assert.AreEqual("Casa", Local.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var Local = _LocalService.Obter(3);
            Local.Nome = "UFS";
			_LocalService.Editar(Local);
			Local = _LocalService.Obter(3);
			Assert.AreEqual("UFS", Local.Nome);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_LocalService.Remover(2);
			// Assert
			Assert.AreEqual(2, _LocalService.ObterTodos().Count());
			var Local = _LocalService.Obter(2);
			Assert.AreEqual(null, Local);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaLocal = _LocalService.ObterTodos();
            // Assert
            Assert.IsInstanceOfType(listaLocal, typeof(IEnumerable<Local>));
            Assert.IsNotNull(listaLocal);
            Assert.AreEqual(3, listaLocal.Count());
			Assert.AreEqual(1, listaLocal.First().Id);
			Assert.AreEqual("Elétrico", listaLocal.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var Local = _LocalService.Obter(1);
			Assert.IsNotNull(Local);
			Assert.AreEqual("Casa", Local.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var Local = _LocalService.ObterPorNome("Casa");
			Assert.IsNotNull(Local);
			Assert.AreEqual(1, Local.Count());
			Assert.AreEqual("Casa", Local.First().Nome);
		}
	}
}
