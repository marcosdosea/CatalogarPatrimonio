using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class AlmoxarifadoController : Controller
    {
		IAlmoxarifadoService _almoxarifadoService;
		IMapper _mapper;

		// private readonly IAlmoxarifadoService almoxarifadoService;

		public AlmoxarifadoController(IAlmoxarifadoService almoxarifadoService, IMapper mapper)
		{
			_almoxarifadoService = almoxarifadoService;
			_mapper = mapper;
		}

		// GET: AlmoxarifadoController
		public ActionResult Index()
		{
			var listaAlmoxarifado = _almoxarifadoService.ObterTodos();
			var listaAlmoxarifadoModel = _mapper.Map<List<AlmoxarifadoModel>>(listaAlmoxarifado);
			return View(listaAlmoxarifadoModel);
		}

		// GET: AlmoxarifadoController/Details/5
		public ActionResult Details(int id)
		{
			Almoxarifado almoxarifado = _almoxarifadoService.Obter(id);
			AlmoxarifadoModel almoxarifadoModel = _mapper.Map<AlmoxarifadoModel>(almoxarifado);
			return View(almoxarifadoModel);
		}

		// GET: AlmoxarifadoController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: AlmoxarifadoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(AlmoxarifadoModel almoxarifadoModel)
		{
			if (ModelState.IsValid)
			{
				var almoxarifado = _mapper.Map<Almoxarifado>(almoxarifadoModel);
				_almoxarifadoService.Inserir(almoxarifado);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: AlmoxarifadoController/Edit/5
		public ActionResult Edit(int id)
		{
			Almoxarifado almoxarifado = _almoxarifadoService.Obter(id);
			AlmoxarifadoModel almoxarifadoModel = _mapper.Map<AlmoxarifadoModel>(almoxarifado);
			return View(almoxarifadoModel);
		}

		// POST: AlmoxarifadoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, AlmoxarifadoModel almoxarifadoModel)
		{
			if (ModelState.IsValid)
			{
				var almoxarifado = _mapper.Map<Almoxarifado>(almoxarifadoModel);
				_almoxarifadoService.Editar(almoxarifado);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: AlmoxarifadoController/Delete/5
		public ActionResult Delete(int id)
		{
			Almoxarifado almoxarifado = _almoxarifadoService.Obter(id);
			AlmoxarifadoModel almoxarifadoModel = _mapper.Map<AlmoxarifadoModel>(almoxarifado);
			return View(almoxarifadoModel);
		}

		// POST: AlmoxarifadoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, AlmoxarifadoModel almoxarifado)
		{
			_almoxarifadoService.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
