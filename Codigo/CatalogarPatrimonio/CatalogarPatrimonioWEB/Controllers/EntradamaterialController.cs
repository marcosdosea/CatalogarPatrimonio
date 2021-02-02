using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;
using System;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class EntradamaterialController : Controller
    {
        IEntradamaterialService _entradamaterialService;
        IMapper _mapper;

        // private readonly IEntradamaterial entradamaterial;
        public EntradamaterialController(IEntradamaterialService entradamaterialService, IMapper mapper)
        {
            _entradamaterialService = entradamaterialService;
            _mapper = mapper;
        }

        // GET: EntradamaterialController
        public ActionResult Index()
        {
            var listaEntradamaterial = _entradamaterialService.ObterTodos();
            var listaentradamaterialModel = _mapper.Map<List<EntradamaterialModel>>(listaEntradamaterial);
            return View(listaentradamaterialModel);
        }

        // GET: EntradamaterialController/Details/5
        public ActionResult Details(int id)
        {
            Entradamaterial entradamaterial = _entradamaterialService.Obter(id);
            EntradamaterialModel entradamaterialModel = _mapper.Map<EntradamaterialModel>(entradamaterial);
            return View(entradamaterialModel);
        }

        // GET: EntradamaterialController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: EntradamaterialController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntradamaterialModel entradamaterialModel)
        {
            if (ModelState.IsValid)
            {
                var entradamaterial = _mapper.Map<Entradamaterial>(entradamaterialModel);
                _entradamaterialService.Inserir(entradamaterial);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EntradamaterialController/Edit/5
        public ActionResult Edit(int id)
        {
            Entradamaterial entradamaterial = _entradamaterialService.Obter(id);
            EntradamaterialModel entradamaterialModel = _mapper.Map<EntradamaterialModel>(entradamaterial);
            return View(entradamaterialModel);
        }

        // POST: EntradamaterialController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EntradamaterialModel entradamaterialModel)
        {
            if (ModelState.IsValid)
            {
                var entradamaterial = _mapper.Map<Entradamaterial>(entradamaterialModel);
                _entradamaterialService.Editar(entradamaterial);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EntradamaterialController/Delete/5
        public ActionResult Delete(int id)
        {
            Entradamaterial entradamaterial = _entradamaterialService.Obter(id);
            EntradamaterialModel entradamaterialModel = _mapper.Map<EntradamaterialModel>(entradamaterial);
            return View(entradamaterialModel);
        }



        // POST: EntradamaterialController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EntradamaterialModel entradamaterial)
        {
            _entradamaterialService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
