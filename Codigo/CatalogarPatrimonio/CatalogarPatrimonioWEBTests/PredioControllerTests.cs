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
	public class PredioControllerTests
	{
		private static PredioController controller;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<IPredioService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new PredioProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestPredio());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetPredio());
			mockService.Setup(service => service.Editar(It.IsAny<Predio>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Predio>()))
				.Verifiable();
			controller = new PredioController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PredioModel>));
			List<PredioModel> lista = (List<PredioModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PredioModel));
			PredioModel PredioModel = (PredioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Eletrônico", PredioModel.Nome);
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
			var result = controller.Create(GetNewPredio());

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
			var result = controller.Create(GetNewPredio());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PredioModel));
			PredioModel PredioModel = (PredioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Eletrônico", PredioModel.Nome);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetPredioModel().Id, GetTargetPredioModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PredioModel));
			PredioModel PredioModel = (PredioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Eletrônico", PredioModel.Nome);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetPredioModel().Id, GetTargetPredioModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static PredioModel GetNewPredio()
		{
			return new PredioModel
			{
				Id = 4,
				Nome = "Elétrico",
			};

		}
		private static Predio GetTargetPredio()
		{
			return new Predio
			{
				Id = 1,
				Nome = "Eletrônico",
			};
		}

		private static PredioModel GetTargetPredioModel()
		{
			return new PredioModel
			{
				Id = 2,
				Nome = "Eletrônico",
			};
		}

		private static IEnumerable<Predio> GetTestPredio()
		{
			return new List<Predio>
			{
				new Predio
				{
					Id = 1,
					Nome = "Campus São Criatovão",
				},
				new Predio
				{
					Id = 2,
					Nome = "Campus Itabaiana",
				},
				new Predio
				{
					Id = 3,
					Nome = "Campus Gloria",
				},
			};
		}
	}
}