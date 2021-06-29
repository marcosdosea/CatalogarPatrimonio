using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
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
	public class PessoaControllerTests
	{
		private static PessoaController controller;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<IPessoaService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new PessoaProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestPessoaes());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetPessoa());
			mockService.Setup(service => service.Editar(It.IsAny<Pessoa>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Pessoa>()))
				.Verifiable();
			controller = new PessoaController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaModel>));
			List<PessoaModel> lista = (List<PessoaModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
			PessoaModel PessoaModel = (PessoaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Daniel Santos", PessoaModel.nome);
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
			var result = controller.Create(GetNewPessoa());

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
			controller.ModelState.AddModelError("nome", "Campo requerido");

			// Act
			var result = controller.Create(GetNewPessoa());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
			PessoaModel PessoaModel = (PessoaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Daniel Santos", PessoaModel.nome);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetPessoaModel().Id, GetTargetPessoaModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
			PessoaModel PessoaModel = (PessoaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Daniel Santos", PessoaModel.nome);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetPessoaModel().Id, GetTargetPessoaModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static PessoaModel GetNewPessoa()
		{
			return new PessoaModel
			{
				Id = 4,
				nome = "Wagner Prata",
				dataNascimento = new DateTime(1997, 11, 06, 0, 0, 0),
				CPF = "06497631577",
				email = "daniel17sants@gmail.com",
				telefone = "79999655134",
				tipo = "Administrador"
			};

		}
		private static Pessoa GetTargetPessoa()
		{
			return new Pessoa
			{
				Id = 1,
				Nome = "Daniel Santos",
				DataNascimento = new DateTime(1997, 11, 06, 0, 0, 0),
				Cpf = "06497631577",
				Email = "daniel17sants@gmail.com",
				Telefone = "79999655134",
				Tipo = "Administrador"
			};
		}

		private static PessoaModel GetTargetPessoaModel()
		{
			return new PessoaModel
			{
				Id = 2,
				nome = "Daniel Santos",
				dataNascimento = new DateTime(1997, 11, 06, 0, 0, 0),
				CPF = "06497631577",
				email = "daniel17sants@gmail.com",
				telefone = "79999655134",
				tipo = "Administrador"
			};
		}

		private static IEnumerable<Pessoa> GetTestPessoaes()
		{
			return new List<Pessoa>
			{
				new Pessoa
				{
					Id = 1,
					Nome = "Rafael Silveira",
					DataNascimento = new DateTime(1997, 11, 06, 0, 0, 0),
					Cpf = "06497631577",
					Email = "daniel17sants@gmail.com",
					Telefone = "79999655134",
					Tipo = "Administrador"
				},
				new Pessoa
				{
					Id = 2,
					Nome = "Daniel Santos",
					DataNascimento = new DateTime(1997, 11, 06, 0, 0, 0),
					Cpf = "06497631577",
					Email = "daniel17sants@gmail.com",
					Telefone = "79999655134",
					Tipo = "Administrador"
				},
				new Pessoa
				{
					Id = 3,
					Nome = "José Carlos",
					DataNascimento = new DateTime(1997, 11, 06, 0, 0, 0),
					Cpf = "06497631577",
					Email = "daniel17sants@gmail.com",
					Telefone = "79999655134",
					Tipo = "Administrador"
				},
			};
		}
	}
}