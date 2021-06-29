using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Core;
using Core.Service;
using AutoMapper;
using CatalogarPatrimonioWEB.Mappers;
using Microsoft.AspNetCore.Mvc;
using CatalogarPatrimonioWEB.Models;
using System;

namespace CatalogarPatrimonioWEB.Controllers.Tests
{
	[TestClass()]
	public class EmpresaControllerTests
	{
		private static EmpresaController controller;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<IEmpresaService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new EmpresaProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestEmpresa());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetEmpresa());
			mockService.Setup(service => service.Editar(It.IsAny<Empresa>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Empresa>()))
				.Verifiable();
			controller = new EmpresaController(mockService.Object, mapper);
		}


        [TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<EmpresaModel>));
			List<EmpresaModel> lista = (List<EmpresaModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EmpresaModel));
			EmpresaModel EmpresaModel = (EmpresaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Eletrônico", EmpresaModel.Nome);
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
			var result = controller.Create(GetNewEmpresa());

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
			var result = controller.Create(GetNewEmpresa());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EmpresaModel));
			EmpresaModel EmpresaModel = (EmpresaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Eletrônico", EmpresaModel.Nome);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetEmpresaModel().Id, GetTargetEmpresaModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

        private object GetTargetEmpresaModel()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
		public void DeleteTest_Post()
		{
			// Act
			var result = controller.Delete(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EmpresaModel));
			EmpresaModel EmpresaModel = (EmpresaModel)viewResult.ViewData.Model;
			Assert.AreEqual("UFS", EmpresaModel.Nome);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetEmpresaModel().Id, GetTargetEmpresaModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static EmpresaModel GetNewEmpresa()
		{
			return new EmpresaModel
			{
				Id = 4,
				Nome = "UFS",
			};

		}
		private static Empresa GetTargetEmpresa()
		{
			return new Empresa
			{
				Id = 1,
				Nome = "UFS",
			};
		}

		private static EmpresaModel GetTargetEmpresaModel()
		{
			return new EmpresaModel
			{
				Id = 2,
				Nome = "UFS",
			};
		}

		private static IEnumerable<Empresa> GetTestEmpresa()
		{
			return new List<Empresa>
			{
				new Empresa
				{
					Id = 1,
					Nome = "UFS",
				},
				new Empresa
				{
					Id = 2,
					Nome = "Oficina",
				},
				new Empresa
				{
					Id = 3,
					Nome = "Supermercado",
				},
			};
		}
	}
}
