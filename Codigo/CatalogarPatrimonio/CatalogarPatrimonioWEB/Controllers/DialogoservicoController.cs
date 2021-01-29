using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class DialogoservicoController : Controller
    {
        IDialogoservicoService _dialogoservicoService;
        IMapper _mapper;

        // private readonly IAlmoxarifadoService almoxarifadoService;

        public DialogoservicoController(IDialogoservicoService dialogoServicoService, IMapper mapper)
        {
            _dialogoservicoService = dialogoServicoService;
            _mapper = mapper;
        }

		// GET: DialogoservicoController
		public ActionResult Index()
		{
			var listaDialogoservico = _dialogoservicoService.ObterTodos();
			var listaDialogoservicoModel = _mapper.Map<List<DialogoservicoModel>>(listaDialogoservico);
			return View(listaDialogoservicoModel);
		}

		// GET: DialogoservicoController/Details/5
		public ActionResult Details(int id)
		{
			Dialogoservico dialogoServico = _dialogoservicoService.Obter(id);
			DialogoservicoModel dialogoServicoModel = _mapper.Map<DialogoservicoModel>(dialogoServico);
			return View(dialogoServicoModel);
		}

		// GET: DialogoservicoController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: DialogoservicoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(DialogoservicoModel dialogoServicoModel)
		{
			if (ModelState.IsValid)
			{
				var dialogoservico = _mapper.Map<Dialogoservico>(dialogoServicoModel);
				_dialogoservicoService.Inserir(dialogoservico);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: DialogoservicoController/Edit/5
		public ActionResult Edit(int id)
		{
			Dialogoservico dialogoservico = _dialogoservicoService.Obter(id);
			DialogoservicoModel dialogoservicoModel = _mapper.Map<DialogoservicoModel>(dialogoservico);
			return View(dialogoservicoModel);
		}

		// POST: DialogoservicoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, DialogoservicoModel dialogoServicoModel)
		{
			if (ModelState.IsValid)
			{
				var dialogoservico = _mapper.Map<Dialogoservico>(dialogoServicoModel);
				_dialogoservicoService.Editar(dialogoservico);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: DialogoservicoController/Delete/5
		public ActionResult Delete(int id)
		{
			Dialogoservico dialogoservico = _dialogoservicoService.Obter(id);
			DialogoservicoModel dialogoservicoModel = _mapper.Map<DialogoservicoModel>(dialogoservico);
			return View(dialogoservicoModel);
		}

		// POST: DialogoservicoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, DialogoservicoModel almoxarifado)
		{
			_dialogoservicoService.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
