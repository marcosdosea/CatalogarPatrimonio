using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Core;
using Core.Service;
using AutoMapper;
using CatalogarPatrimonioWEB.Mappers;
using Microsoft.AspNetCore.Mvc;
using CatalogarPatrimonioWEB.Models;

namespace CatalogarPatrimonioWEB.Controllers.Tests
{
	[TestClass()]
	public class ServicoControllerTests
	{
		private static ServicoController controller;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<IServicoService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new ServicoProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestServicos());
			mockService.Setup(service => service.Obter(2))
				.Returns(GetTargetServico());
			mockService.Setup(service => service.Editar(It.IsAny<Servico>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Servico>()))
				.Verifiable();
			controller = new ServicoController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ServicoModel>));
			List<ServicoModel> lista = (List<ServicoModel>)viewResult.ViewData.Model;
			Assert.AreEqual(3, lista.Count);
		}

		[TestMethod()]
		public void DetailsTest()
		{
			// Act
			var result = controller.Details(2);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ServicoModel));
			ServicoModel ServicoModel = (ServicoModel)viewResult.ViewData.Model;
			Assert.AreEqual("Fechadura emperrada", ServicoModel.Descricao);
		}

		[TestMethod()]
		public void CreateTest()
		{
			// Act
			var result = controller.Create();
			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod()]
		public void CreateTest_Valid()
		{
			// Act
			var result = controller.Create(GetNewServico());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void CreateTest_InValid()
		{
			// Arrange
			controller.ModelState.AddModelError("Descrição", "Campo requerido");

			// Act
			var result = controller.Create(GetNewServico());

			// Assert
			Assert.AreEqual(1, controller.ModelState.ErrorCount);
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void EditTest_Post()
		{
			// Act
			var result = controller.Edit(2);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ServicoModel));
			ServicoModel ServicoModel = (ServicoModel)viewResult.ViewData.Model;
			Assert.AreEqual("Fechadura emperrada", ServicoModel.Descricao);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetServicoModel().Id, GetTargetServicoModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void DeleteTest_Post()
		{
			// Act
			var result = controller.Delete(2);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ServicoModel));
			ServicoModel ServicoModel = (ServicoModel)viewResult.ViewData.Model;
			Assert.AreEqual("Fechadura emperrada", ServicoModel.Descricao);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetServicoModel().Id, GetTargetServicoModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static ServicoModel GetNewServico()
		{
			return new ServicoModel
			{
				Id = 4,
				Descricao = "Lampada Queimada",
				IdSolicitante = 2,
				IdAlmoxarife =  1,
				IdTecnico =  1,
				IdLocal =  2,
			};

		}
		private static Servico GetTargetServico()
		{
			return new Servico
			{
				Id = 2,
				Descricao = "Fechadura emperrada",
				IdSolicitante = 2,
				IdAlmoxarife =  1,
				IdTecnico =  1,
				IdLocal =  2,
			};
		}

		private static ServicoModel GetTargetServicoModel()
		{
			return new ServicoModel
			{
				Id = 2,
				Descricao = "Fechadura emperrada",
				IdSolicitante = 2,
				IdAlmoxarife =  1,
				IdTecnico =  1,
				IdLocal =  2,
			};
		}

		private static IEnumerable<Servico> GetTestServicos()
		{
			return new List<Servico>
			{
				new Servico
				{
					Id = 1,
					Descricao = "Lampada queimada",
					IdSolicitante = 2,
					IdAlmoxarife =  1,
					IdTecnico =  1,
					IdLocal =  2,
				},
				new Servico
				{
					Id = 2,
					Descricao = "Fechadura emperrada",
					IdSolicitante = 1,
					IdAlmoxarife =  1,
					IdTecnico =  1,
					IdLocal =  1,
				},
				new Servico
				{
					Id = 3,
					Descricao = "Ar condicionado quebrou",
					IdSolicitante = 3,
					IdAlmoxarife =  1,
					IdTecnico =  1,
					IdLocal =  3,
				},
			};
		}
	}
}