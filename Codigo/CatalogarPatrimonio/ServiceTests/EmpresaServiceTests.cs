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
	public class EmpresaServiceTests
	{
		private CatalogarPatrimonioContext _context;
		private IEmpresaService _EmpresaService;

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
			var Empresa = new List<Empresa>
				{
					new Empresa { Id = 1, Nome = "UFS - ITABAIANA"},
					new Empresa { Id = 2, Nome = "Supermercado"},
					new Empresa { Id = 3, Nome = "Oficina"},
				};

			_context.AddRange(Empresa);
			_context.SaveChanges();

			_EmpresaService = new EmpresaService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_EmpresaService.Inserir(new Empresa() { Id = 4, Nome = "Oficina" });
			// Assert
			Assert.AreEqual(4, _EmpresaService.ObterTodos().Count());
			var Empresa = _EmpresaService.Obter(4);
			Assert.AreEqual("Oficina", Empresa.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var Empresa = _EmpresaService.Obter(3);
			Empresa.Nome = "Carpintaria";
			_EmpresaService.Editar(Empresa);
			Empresa = _EmpresaService.Obter(3);
			Assert.AreEqual("Carpintaria", Empresa.Nome);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_EmpresaService.Remover(2);
			// Assert
			Assert.AreEqual(2, _EmpresaService.ObterTodos().Count());
			var Empresa = _EmpresaService.Obter(2);
			Assert.AreEqual(null, Empresa);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaEmpresa = _EmpresaService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaEmpresa, typeof(IEnumerable<Empresa>));
			Assert.IsNotNull(listaEmpresa);
			Assert.AreEqual(3, listaEmpresa.Count());
			Assert.AreEqual(1, listaEmpresa.First().Id);
			Assert.AreEqual("UFS", listaEmpresa.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var Empresa = _EmpresaService.Obter(1);
			Assert.IsNotNull(Empresa);
			Assert.AreEqual("UFS", Empresa.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var Empresa = _EmpresaService.ObterPorNome("UFS");
			Assert.IsNotNull(Empresa);
			Assert.AreEqual(1, Empresa.Count());
			Assert.AreEqual("Elétrico", Empresa.First().Nome);
		}
	}
}
