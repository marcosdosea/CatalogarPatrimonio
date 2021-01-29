using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class LocalController : Controller
    {
		ILocalService _localService;
		IMapper _mapper;

		// private readonly ILocalService localService;

		public LocalController(ILocalService localService, IMapper mapper)
		{
			_localService = localService;
			_mapper = mapper;
		}

		// GET: LocalController
		public ActionResult Index()
		{
			var listaLocal = _localService.ObterTodos();
			var listaLocalModel = _mapper.Map<List<LocalModel>>(listaLocal);
			return View(listaLocalModel);
		}

		// GET: LocalController/Details/5
		public ActionResult Details(int id)
		{
			Local local = _localService.Obter(id);
			LocalModel localModel = _mapper.Map<LocalModel>(local);
			return View(localModel);
		}

		// GET: LocalController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: LocalController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(LocalModel localModel)
		{
			if (ModelState.IsValid)
			{
				var local = _mapper.Map<Local>(localModel);
				_localService.Inserir(local);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: LocalController/Edit/5
		public ActionResult Edit(int id)
		{
			Local local = _localService.Obter(id);
			LocalModel localModel = _mapper.Map<LocalModel>(local);
			return View(localModel);
		}

		// POST: LocalController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, LocalModel localModel)
		{
			if (ModelState.IsValid)
			{
				var local = _mapper.Map<Local>(localModel);
				_localService.Editar(local);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: LocalController/Delete/5
		public ActionResult Delete(int id)
		{
			Local local = _localService.Obter(id);
			LocalModel localModel = _mapper.Map<LocalModel>(local);
			return View(localModel);
		}

		// POST: LocalController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, LocalModel local)
		{
			_localService.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
