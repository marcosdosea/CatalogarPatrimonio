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
	public class MaterialServiceTests
	{
		private CatalogarPatrimonioContext _context;
		private IMaterialService _MaterialService;

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
			var Materiais = new List<Material>
				{
					new Material { Id = 1, Nome = "Lâmpada"},
					new Material { Id = 2, Nome = "Fiação"},
					new Material { Id = 3, Nome = "Interruptor"},
				};

			_context.AddRange(Materiais);
			_context.SaveChanges();

			_MaterialService = new MaterialService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_MaterialService.Inserir(new Material() { Id = 4, Nome = "Ar-Condicionado" });
			// Assert
			Assert.AreEqual(4, _MaterialService.ObterTodos().Count());
			var Material = _MaterialService.Obter(4);
			Assert.AreEqual("Ar-Condicionado", Material.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var Material = _MaterialService.Obter(3);
			Material.Nome = "Interruptor";
			_MaterialService.Editar(Material);
			Material = _MaterialService.Obter(3);
			Assert.AreEqual("Interruptor", Material.Nome);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_MaterialService.Remover(2);
			// Assert
			Assert.AreEqual(2, _MaterialService.ObterTodos().Count());
			var Material = _MaterialService.Obter(2);
			Assert.AreEqual(null, Material);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaMaterial = _MaterialService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaMaterial, typeof(IEnumerable<Material>));
			Assert.IsNotNull(listaMaterial);
			Assert.AreEqual(3, listaMaterial.Count());
			Assert.AreEqual(1, listaMaterial.First().Id);
			Assert.AreEqual("Lâmpada", listaMaterial.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var Material = _MaterialService.Obter(1);
			Assert.IsNotNull(Material);
			Assert.AreEqual("Lâmpada", Material.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var Materiais = _MaterialService.ObterPorNome("Lâmpada");
			Assert.IsNotNull(Materiais);
			Assert.AreEqual(1, Materiais.Count());
			Assert.AreEqual("Lâmpada", Materiais.First().Nome);
		}
	}
}