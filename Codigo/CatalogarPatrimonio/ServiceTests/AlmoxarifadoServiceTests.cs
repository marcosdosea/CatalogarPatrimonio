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
	public class AlmoxarifadoServiceTests
	{
		private CatalogarPatrimonioContext _context;
		private IAlmoxarifadoService _AlmoxarifadoService;

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
			var Almoxarifado = new List<Almoxarifado>
				{
					new Almoxarifado { Id = 1, Nome = "Elétrico"},
					new Almoxarifado { Id = 2, Nome = "Eletrônico"},
					new Almoxarifado { Id = 3, Nome = "Monumento"},
				};

			_context.AddRange(Almoxarifado);
			_context.SaveChanges();

			_AlmoxarifadoService = new AlmoxarifadoService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_AlmoxarifadoService.Inserir(new Almoxarifado() { Id = 4, Nome = "Refrigeração" });
			// Assert
			Assert.AreEqual(4, _AlmoxarifadoService.ObterTodos().Count());
			var Almoxarifado = _AlmoxarifadoService.Obter(4);
			Assert.AreEqual("Refrigeração", Almoxarifado.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var Almoxarifado = _AlmoxarifadoService.Obter(3);
			Almoxarifado.Nome = "Carpintaria";
			_AlmoxarifadoService.Editar(Almoxarifado);
			Almoxarifado = _AlmoxarifadoService.Obter(3);
			Assert.AreEqual("Carpintaria", Almoxarifado.Nome);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_AlmoxarifadoService.Remover(2);
			// Assert
			Assert.AreEqual(2, _AlmoxarifadoService.ObterTodos().Count());
			var Almoxarifado = _AlmoxarifadoService.Obter(2);
			Assert.AreEqual(null, Almoxarifado);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaAlmoxarifado = _AlmoxarifadoService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaAlmoxarifado, typeof(IEnumerable<Tipopatrimonio>));
			Assert.IsNotNull(listaAlmoxarifado);
			Assert.AreEqual(3, listaAlmoxarifado.Count());
			Assert.AreEqual(1, listaAlmoxarifado.First().Id);
			Assert.AreEqual("Elétrico", listaAlmoxarifado.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var Almoxarifado = _AlmoxarifadoService.Obter(1);
			Assert.IsNotNull(Almoxarifado);
			Assert.AreEqual("Elétrico", Almoxarifado.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var TipoAlmoxarifado = _AlmoxarifadoService.ObterPorNome("Elétrico");
			Assert.IsNotNull(TipoAlmoxarifado);
			Assert.AreEqual(1, TipoAlmoxarifado.Count());
			Assert.AreEqual("Elétrico", TipoAlmoxarifado.First().Nome);
		}
	}
}