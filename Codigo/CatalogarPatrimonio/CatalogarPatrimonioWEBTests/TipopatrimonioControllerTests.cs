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
	public class TipopatrimonioControllerTests
	{
		private static TipopatrimonioController controller;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<ITipopatrimonioService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new TipopatrimonioProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestTipopatrimonioes());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetTipopatrimonio());
			mockService.Setup(service => service.Editar(It.IsAny<Tipopatrimonio>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Tipopatrimonio>()))
				.Verifiable();
			controller = new TipopatrimonioController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<TipopatrimonioModel>));
			List<TipopatrimonioModel> lista = (List<TipopatrimonioModel>)viewResult.ViewData.Model;
			Assert.AreEqual(3, lista.Count);
		}

		[TestMethod()]
		public void DetailsTest()
		{
			// Act
			var result = controller.Details(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipopatrimonioModel));
			TipopatrimonioModel TipopatrimonioModel = (TipopatrimonioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Eletrônico", TipopatrimonioModel.Nome);
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
			var result = controller.Create(GetNewTipopatrimonio());

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
			controller.ModelState.AddModelError("Nome", "Campo requerido");

			// Act
			var result = controller.Create(GetNewTipopatrimonio());

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
			var result = controller.Edit(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipopatrimonioModel));
			TipopatrimonioModel TipopatrimonioModel = (TipopatrimonioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Eletrônico", TipopatrimonioModel.Nome);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetTipopatrimonioModel().Id, GetTargetTipopatrimonioModel());

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
			var result = controller.Delete(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipopatrimonioModel));
			TipopatrimonioModel TipopatrimonioModel = (TipopatrimonioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Eletrônico", TipopatrimonioModel.Nome);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetTipopatrimonioModel().Id, GetTargetTipopatrimonioModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static TipopatrimonioModel GetNewTipopatrimonio()
		{
			return new TipopatrimonioModel
			{
				Id = 4,
				Nome = "Elétrico",
			};

		}
		private static Tipopatrimonio GetTargetTipopatrimonio()
		{
			return new Tipopatrimonio
			{
				Id = 1,
				Nome = "Eletrônico",
			};
		}

		private static TipopatrimonioModel GetTargetTipopatrimonioModel()
		{
			return new TipopatrimonioModel
			{
				Id = 2,
				Nome = "Eletrônico",
			};
		}

		private static IEnumerable<Tipopatrimonio> GetTestTipopatrimonioes()
		{
			return new List<Tipopatrimonio>
			{
				new Tipopatrimonio
				{
					Id = 1,
					Nome = "Monumento",
				},
				new Tipopatrimonio
				{
					Id = 2,
					Nome = "Eletrônico",
				},
				new Tipopatrimonio
				{
					Id = 3,
					Nome = "Refrigeração",
				},
			};
		}
	}
}