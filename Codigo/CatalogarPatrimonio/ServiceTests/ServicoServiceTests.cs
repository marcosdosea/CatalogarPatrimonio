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
	public class ServicoServiceTests
	{
		private CatalogarPatrimonioContext _context;
		private IServicoService _ServicoService;


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
			var Servico = new List<Servico>
				{
					new Servico { Id = 1, Descricao = "Ar condicionado quebrou"},
					new Servico { Id = 2, Descricao = "Fechadura emperrada"},
					new Servico { Id = 3, Descricao = "Lampada queimada"},
				};

			_context.AddRange(Servico);
			_context.SaveChanges();

			_ServicoService = new ServicoService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_ServicoService.Inserir(new Servico() { Id = 4, Descricao = "Lampada queimada" });
			// Assert
			Assert.AreEqual(4, _ServicoService.ObterTodos().Count());
			var Servico = _ServicoService.Obter(4);
			Assert.AreEqual("Lampada queimada", Servico.Descricao);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var Servico = _ServicoService.Obter(3);
            Servico.Descricao = "Ar condicionado queimado";
			_ServicoService.Editar(Servico);
			Servico = _ServicoService.Obter(3);
			Assert.AreEqual("Ar condicionado queimado", Servico.Descricao);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_ServicoService.Remover(2);
			// Assert
			Assert.AreEqual(2, _ServicoService.ObterTodos().Count());
			var Servico = _ServicoService.Obter(2);
			Assert.AreEqual(null, Servico);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaServico = _ServicoService.ObterTodos();
            // Assert
            Assert.IsInstanceOfType(listaServico, typeof(IEnumerable<Servico>));
            Assert.IsNotNull(listaServico);
            Assert.AreEqual(3, listaServico.Count());
			Assert.AreEqual(1, listaServico.First().Id);
			Assert.AreEqual("Ar condicionado quebrou", listaServico.First().Descricao);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var Servico = _ServicoService.Obter(2);
			Assert.IsNotNull(Servico);
			Assert.AreEqual("Fechadura emperrada", Servico.Descricao);
		}
	}
}
