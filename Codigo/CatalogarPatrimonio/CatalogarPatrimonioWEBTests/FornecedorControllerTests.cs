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
	public class FornecedorControllerTests
	{
		private static FornecedorController controller;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<IFornecedorService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new FornecedorProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestFornecedor());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetFornecedor());
			mockService.Setup(service => service.Editar(It.IsAny<Fornecedor>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Fornecedor>()))
				.Verifiable();
			controller = new FornecedorController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<FornecedorModel>));
			List<FornecedorModel> lista = (List<FornecedorModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(FornecedorModel));
			FornecedorModel FornecedorModel = (FornecedorModel)viewResult.ViewData.Model;
			Assert.AreEqual("Wagner", FornecedorModel.Nome);
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
			var result = controller.Create(GetNewFornecedor());

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
			var result = controller.Create(GetNewFornecedor());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(FornecedorModel));
			FornecedorModel FornecedorModel = (FornecedorModel)viewResult.ViewData.Model;
			Assert.AreEqual("Wagner", FornecedorModel.Nome);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetFornecedorModel().IdFornecedor, GetTargetFornecedorModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(FornecedorModel));
			FornecedorModel FornecedorModel = (FornecedorModel)viewResult.ViewData.Model;
			Assert.AreEqual("Wagner", FornecedorModel.Nome);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetFornecedorModel().IdFornecedor, GetTargetFornecedorModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static FornecedorModel GetNewFornecedor()
		{
			return new FornecedorModel
			{
				IdFornecedor = 4,
				Nome = "Wagner",
			};

		}
		private static Fornecedor GetTargetFornecedor()
		{
			return new Fornecedor
			{
				Id = 1,
				Nome = "Wagner",
			};
		}

		private static FornecedorModel GetTargetFornecedorModel()
		{
			return new FornecedorModel
			{
				IdFornecedor = 2,
				Nome = "Rafael",
			};
		}

		private static IEnumerable<Fornecedor> GetTestFornecedor()
		{
			return new List<Fornecedor>
			{
				new Fornecedor
				{
					Id = 1,
					Nome = "Daniel",
				},
				new Fornecedor
				{
					Id = 2,
					Nome = "Junior",
				},
				new Fornecedor
				{
					Id = 3,
					Nome = "Liliane",
				},
			};
		}
	}
}