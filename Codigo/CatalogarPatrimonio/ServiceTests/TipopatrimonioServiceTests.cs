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
	public class TipopatrimonioServiceTests
	{
		private CatalogarPatrimonioContext _context;
		private ITipopatrimonioService _TipopatrimonioService;

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
			var Tipopatrimonioes = new List<Tipopatrimonio>
				{
					new Tipopatrimonio { Id = 1, Nome = "Elétrico"},
					new Tipopatrimonio { Id = 2, Nome = "Eletrônico"},
					new Tipopatrimonio { Id = 3, Nome = "Monumento"},
				};

			_context.AddRange(Tipopatrimonioes);
			_context.SaveChanges();

			_TipopatrimonioService = new TipopatrimonioService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_TipopatrimonioService.Inserir(new Tipopatrimonio() { Id = 4, Nome = "Refrigeração" });
			// Assert
			Assert.AreEqual(4, _TipopatrimonioService.ObterTodos().Count());
			var Tipopatrimonio = _TipopatrimonioService.Obter(4);
			Assert.AreEqual("Refrigeração", Tipopatrimonio.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var Tipopatrimonio = _TipopatrimonioService.Obter(3);
			Tipopatrimonio.Nome = "Carpintaria";
			_TipopatrimonioService.Editar(Tipopatrimonio);
			Tipopatrimonio = _TipopatrimonioService.Obter(3);
			Assert.AreEqual("Carpintaria", Tipopatrimonio.Nome);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_TipopatrimonioService.Remover(2);
			// Assert
			Assert.AreEqual(2, _TipopatrimonioService.ObterTodos().Count());
			var Tipopatrimonio = _TipopatrimonioService.Obter(2);
			Assert.AreEqual(null, Tipopatrimonio);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaTipopatrimonio = _TipopatrimonioService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaTipopatrimonio, typeof(IEnumerable<Tipopatrimonio>));
			Assert.IsNotNull(listaTipopatrimonio);
			Assert.AreEqual(3, listaTipopatrimonio.Count());
			Assert.AreEqual(1, listaTipopatrimonio.First().Id);
			Assert.AreEqual("Elétrico", listaTipopatrimonio.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var Tipopatrimonio = _TipopatrimonioService.Obter(1);
			Assert.IsNotNull(Tipopatrimonio);
			Assert.AreEqual("Elétrico", Tipopatrimonio.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var Tipopatrimonioes = _TipopatrimonioService.ObterPorNome("Elétrico");
			Assert.IsNotNull(Tipopatrimonioes);
			Assert.AreEqual(1, Tipopatrimonioes.Count());
			Assert.AreEqual("Elétrico", Tipopatrimonioes.First().Nome);
		}
	}
}