using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class PredioController : Controller
    {
        IPredioService _predioService;
        IMapper _mapper;

        // private readonly IPredioi predio;
        public PredioController(IPredioService predioService, IMapper mapper)
        {
            _predioService = predioService;
            _mapper = mapper;
        }

        // GET: PredioController
        public ActionResult Index()
        {
            var listaPredio = _predioService.ObterTodos();
            var listaPredioModel = _mapper.Map<List<PredioModel>>(listaPredio);
            return View(listaPredioModel);
        }

        // GET: PredioController/Details/5
        public ActionResult Details(int id)
        {
            Predio predio = _predioService.Obter(id);
            PredioModel predioModel = _mapper.Map<PredioModel>(predio);
            return View(predioModel);
        }

        // GET: PredioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PredioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PredioModel predioModel)
        {
            if (ModelState.IsValid)
            {
                var predio = _mapper.Map<Predio>(predioModel);
                _predioService.Inserir(predio);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PredioController/Edit/5
        public ActionResult Edit(int id)
        {
            Predio predio = _predioService.Obter(id);
            PredioModel predioModel = _mapper.Map<PredioModel>(predio);
            return View(predioModel);
        }

        // POST: PredioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PredioModel predioModel)
        {
            if (ModelState.IsValid)
            {
                var predio = _mapper.Map<Predio>(predioModel);
                _predioService.Editar(predio);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PredioController/Delete/5
        public ActionResult Delete(int id)
        {
            Predio predio = _predioService.Obter(id);
            PredioModel predioModel = _mapper.Map<PredioModel>(predio);
            return View(predioModel);
        }

        // POST: PredioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PredioModel predio)
        {
            _predioService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
