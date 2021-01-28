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
        IDialogoServicoService _dialogoServicoService;
        IMapper _mapper;

        // private readonly IAlmoxarifadoService almoxarifadoService;

        public DialogoservicoController(IDialogoServicoService dialogoServicoService, IMapper mapper)
        {
            _dialogoServicoService = dialogoServicoService;
            _mapper = mapper;
        }

		// GET: DialogoservicoController
		public ActionResult Index()
		{
			var listaDialogoServico = _dialogoServicoService.ObterTodos();
			var listaDialogoServicoModel = _mapper.Map<List<DialogoServicoModel>>(listaDialogoServico);
			return View(listaDialogoServicoModel);
		}

		// GET: DialogoservicoController/Details/5
		public ActionResult Details(int id)
		{
			DialogoServico dialogoServico = _dialogoServicoService.Obter(id);
			DialogoServicoModel dialogoServicoModel = _mapper.Map<DialogoServicoModel>(dialogoServico);
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
		public ActionResult Create(DialogoServicoModel dialogoServicoModel)
		{
			if (ModelState.IsValid)
			{
				var dialogoservico = _mapper.Map<DialogoServico>(dialogoServicoModel);
				_dialogoServicoService.Inserir(dialogoservico);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: DialogoservicoController/Edit/5
		public ActionResult Edit(int id)
		{
			DialogoServico dialogoservico = _dialogoServicoService.Obter(id);
			DialogoServicoModel dialogoservicoModel = _mapper.Map<DialogoServicoModel>(dialogoservico);
			return View(dialogoservicoModel);
		}

		// POST: DialogoservicoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, DialogoServicoModel dialogoServicoModel)
		{
			if (ModelState.IsValid)
			{
				var dialogoservico = _mapper.Map<DialogoServico>(dialogoServicoModel);
				_dialogoServicoService.Editar(dialogoservico);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: DialogoservicoController/Delete/5
		public ActionResult Delete(int id)
		{
			DialogoServico dialogoservico = _dialogoServicoService.Obter(id);
			DialogoServicoModel dialogoservicoModel = _mapper.Map<DialogoServicoModel>(dialogoservico);
			return View(dialogoservicoModel);
		}

		// POST: DialogoservicoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, DialogoServicoModel almoxarifado)
		{
			_dialogoServicoService.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
