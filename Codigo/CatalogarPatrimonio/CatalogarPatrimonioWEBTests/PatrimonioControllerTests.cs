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
	public class PatrimonioControllerTests
	{
		private static PatrimonioController controller;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<IPatrimonioService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new PatrimonioProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestPatrimonioes());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetPatrimonio());
			mockService.Setup(service => service.Editar(It.IsAny<Patrimonio>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Patrimonio>()))
				.Verifiable();
			controller = new PatrimonioController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PatrimonioModel>));
			List<PatrimonioModel> lista = (List<PatrimonioModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PatrimonioModel));
			PatrimonioModel PatrimonioModel = (PatrimonioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Museu", PatrimonioModel.Nome);
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
			var result = controller.Create(GetNewPatrimonio());

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
			var result = controller.Create(GetNewPatrimonio());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PatrimonioModel));
			PatrimonioModel PatrimonioModel = (PatrimonioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Museu", PatrimonioModel.Nome);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetPatrimonioModel().Id, GetTargetPatrimonioModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PatrimonioModel));
			PatrimonioModel PatrimonioModel = (PatrimonioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Museu", PatrimonioModel.Nome);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetPatrimonioModel().Id, GetTargetPatrimonioModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static PatrimonioModel GetNewPatrimonio()
		{
			return new PatrimonioModel
			{
				Id = 4,
				Nome = "Igreja",
				Valor = 250000,
				QrCode = "22",
				Numero = 5,
				IdTipoPatrimonio = 1,
				IdLocal = 3,
			};

		}
		private static Patrimonio GetTargetPatrimonio()
		{
			return new Patrimonio
			{
				Id = 1,
				Nome = "Museu",
				Valor = 1000000,
				QrCode = "11",
				Numero = 1,
				IdTipoPatrimonio = 1,
				IdLocal = 2,
			};
		}

		private static PatrimonioModel GetTargetPatrimonioModel()
		{
			return new PatrimonioModel
			{
				Id = 2,
				Nome = "Praça",
				Valor = 50000,
				QrCode = "20",
				Numero = 6,
				IdTipoPatrimonio = 2,
				IdLocal = 1,
			};
		}

		private static IEnumerable<Patrimonio> GetTestPatrimonioes()
		{
			return new List<Patrimonio>
			{
				new Patrimonio
				{
					Id = 1,
					Nome = "Monumento",
					Valor = 2000000,
					QrCode = "25",
					Numero = 2,
					IdTipoPatrimonio = 1,
					IdLocal = 3,
					
				},
				new Patrimonio
				{
					Id = 2,
					Nome = "Museu",
					Valor = 1000000,
					QrCode = "11",
					Numero = 1,
					IdTipoPatrimonio = 1,
					IdLocal = 2,
				},
				new Patrimonio
				{
					Id = 3,
					Nome = "Refrigeração",
					Valor = 250000,
					QrCode = "12",
					Numero = 11,
					IdTipoPatrimonio = 1,
					IdLocal = 5,
				},
			};
		}
	}
}