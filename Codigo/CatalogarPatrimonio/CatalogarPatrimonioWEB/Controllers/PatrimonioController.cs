using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class PatrimonioController : Controller
    {
        IPatrimonioService _patrimonioService;
        IMapper _mapper;

        // private readonly IPatrimonioService patrimonioService;
        public PatrimonioController(IPatrimonioService patrimonioService, IMapper mapper)
        {
            _patrimonioService = patrimonioService;
            _mapper = mapper;
        }

        // GET: PatrimonioController
        public ActionResult Index()
        {
            var listaPatrimonio = _patrimonioService.ObterTodos();
            var listaPatrimonioModel = _mapper.Map<List<PatrimonioModel>>(listaPatrimonio);
            return View(listaPatrimonioModel);
        }

        // GET: PatrimonioController/Details/5
        public ActionResult Details(int id)
        {
            Patrimonio patrimonio = _patrimonioService.Obter(id);
            PatrimonioModel patrimonioModel = _mapper.Map<PatrimonioModel>(patrimonio);
            return View(patrimonioModel);
        }

        // GET: PatrimonioController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: PatrimonioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatrimonioModel patrimonioModel)
        {
            if (ModelState.IsValid)
            {
                var patrimonio = _mapper.Map<Patrimonio>(patrimonioModel);
                _patrimonioService.Inserir(patrimonio);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PatrimonioController/Edit/5
        public ActionResult Edit(int id)
        {
            Patrimonio patrimonio = _patrimonioService.Obter(id);
            PatrimonioModel patrimonioModel = _mapper.Map<PatrimonioModel>(patrimonio);
            return View(patrimonioModel);
        }

        // POST: PatrimonioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PatrimonioModel patrimonioModel)
        {
            if (ModelState.IsValid)
            {
                var patrimonio = _mapper.Map<Patrimonio>(patrimonioModel);
                _patrimonioService.Editar(patrimonio);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PatrimonioController/Delete/5
        public ActionResult Delete(int id)
        {
            Patrimonio patrimonio = _patrimonioService.Obter(id);
            PatrimonioModel patrimonioModel = _mapper.Map<PatrimonioModel>(patrimonio);
            return View(patrimonioModel);
        }



        // POST: PatrimonioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PatrimonioModel patrimonio)
        {
            _patrimonioService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
