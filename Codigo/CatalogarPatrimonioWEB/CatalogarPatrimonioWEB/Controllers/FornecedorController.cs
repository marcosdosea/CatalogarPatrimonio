using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
	public class FornecedorController : Controller
	{
		IFornecedorService _fornecedorService;
		IMapper _mapper;

		// private readonly IFornecedorService fornecedorService;

		public FornecedorController(IFornecedorService fornecedorService, IMapper mapper)
		{
			_fornecedorService = fornecedorService;
			_mapper = mapper;
		}

		// GET: FornecedorController
		public ActionResult Index()
		{
			var listaFornecedor = _fornecedorService.ObterTodos();
			var listaFornecedorModel = _mapper.Map<List<FornecedorModel>>(listaFornecedor);
			return View(listaFornecedorModel);
		}

		// GET: FornecedorController/Details/5
		public ActionResult Details(int id)
		{
			Fornecedor fornecedor = _fornecedorService.Obter(id);
			FornecedorModel fornecedorModel = _mapper.Map<FornecedorModel>(fornecedor);
			return View(fornecedorModel);
		}

		// GET: FornecedorController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: FornecedorController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(FornecedorModel fornecedorModel)
		{
			if (ModelState.IsValid)
			{
				var fornecedor = _mapper.Map<Fornecedor>(fornecedorModel);
				_fornecedorService.Inserir(fornecedor);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: FornecedorController/Edit/5
		public ActionResult Edit(int id)
		{
			Fornecedor fornecedor = _fornecedorService.Obter(id);
			FornecedorModel fornecedorModel = _mapper.Map<FornecedorModel>(fornecedor);
			return View(fornecedorModel);
		}

		// POST: FornecedorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, FornecedorModel fornecedorModel)
		{
			if (ModelState.IsValid)
			{
				var fornecedor = _mapper.Map<Fornecedor>(fornecedorModel);
				_fornecedorService.Editar(fornecedor);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: FornecedorController/Delete/5
		public ActionResult Delete(int id)
		{
			Fornecedor fornecedor = _fornecedorService.Obter(id);
			FornecedorModel fornecedorModel = _mapper.Map<FornecedorModel>(fornecedor);
			return View(fornecedorModel);
		}

		// POST: FornecedorController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, FornecedorModel fornecedor)
		{
			_fornecedorService.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
