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
	public class LocalControllerTests
	{
		private static LocalController controller;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<ILocalService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new LocalProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestLocal());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetLocal());
			mockService.Setup(service => service.Editar(It.IsAny<Local>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Local>()))
				.Verifiable();
			controller = new LocalController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<LocalModel>));
			List<LocalModel> lista = (List<LocalModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(LocalModel));
			LocalModel LocalModel = (LocalModel)viewResult.ViewData.Model;
			Assert.AreEqual("Predio", LocalModel.Nome);
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
			var result = controller.Create(GetNewLocal());

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
			var result = controller.Create(GetNewLocal());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(LocalModel));
			LocalModel LocalModel = (LocalModel)viewResult.ViewData.Model;
			Assert.AreEqual("Predio", LocalModel.Nome);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetLocal().Id, GetTargetLocal());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(LocalModel));
			LocalModel LocalModel = (LocalModel)viewResult.ViewData.Model;
			Assert.AreEqual("Predio", LocalModel.Nome);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetLocal().Id, GetTargetLocal());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static LocalModel GetNewLocal()
		{
			return new LocalModel
			{
				Id = 4,
				Nome = "Local",
			};

		}
		private static Tipopatrimonio GetTargetTipopatrimonio()
		{
			return new Local
			{
				Id = 1,
				Nome = "Predio",
			};
		}

		private static LocalModel GetTargetLocal()
		{
			return new LocalModel
			{
				Id = 2,
				Nome = "Predio",
			};
		}

		private static IEnumerable<Local> GetTestLocales()
		{
			return new List<Local>
			{
				new Local
				{
					Id = 1,
					Nome = "Bloco D",
				},
				new Local
				{
					Id = 2,
					Nome = "Predio",
				},
				new Local
				{
					Id = 3,
					Nome = "Casa",
				},
			};
		}
	}
}
