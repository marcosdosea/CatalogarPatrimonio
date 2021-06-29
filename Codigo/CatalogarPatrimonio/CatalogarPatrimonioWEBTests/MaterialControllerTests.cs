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
	public class MaterialControllerTests
	{
		private static MaterialController controller;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<ITipopatrimonioService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new TipopatrimonioProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestMateriais());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetMaterial());
			mockService.Setup(service => service.Editar(It.IsAny<Material>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Material>()))
				.Verifiable();
			controller = new MaterialController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<MaterialModel>));
			List<MaterialModel> lista = (List<MaterialModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MaterialModel));
			MaterialModel MaterialModel = (MaterialModel)viewResult.ViewData.Model;
			Assert.AreEqual("Eletrônico", MaterialModel.Nome);
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
			var result = controller.Create(GetNewMaterial());

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
			var result = controller.Create(GetNewMaterial());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MaterialModel));
			MaterialModel MaterialModel = (MaterialModel)viewResult.ViewData.Model;
			Assert.AreEqual("Lâmpada", MaterialModel.Nome);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetMaterialModel().Id, GetTargetMaterialModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MaterialModel));
			MaterialModel MaterialModel = (MaterialModel)viewResult.ViewData.Model;
			Assert.AreEqual("Lâmpada", MaterialModel.Nome);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetMaterialModel().Id, GetTargetMaterialModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static MaterialModel GetNewMaterial()
		{
			return new MaterialModel
			{
				Id = 4,
				Nome = "Lâmpada",
			};

		}
		private static Material GetTargetMaterial()
		{
			return new Material
			{
				Id = 1,
				Nome = "Lâmpada",
			};
		}

		private static MaterialModel GetTargetMaterial()
		{
			return new MaterialModel
			{
				Id = 2,
				Nome = "Lâmpada",
			};
		}

		private static IEnumerable<Material> GetTestMateriais()
		{
			return new List<Material>
			{
				new Material
				{
					Id = 1,
					Nome = "Alicate",
				},
				new Material
				{
					Id = 2,
					Nome = "Fiação",
				},
				new Material
				{
					Id = 3,
					Nome = "Interruptor",
				},
			};
		}
	}
}