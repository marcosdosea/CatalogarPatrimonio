using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class TipopatrimonioController : Controller
    {
        ITipopatrimonioService _tipoPatrimonioService;
        IMapper _mapper;

        // private readonly ITipopatrimonio tipoPatrimonio;
        public TipopatrimonioController(ITipopatrimonioService tipoPatrimonioService, IMapper mapper)
        {
            _tipoPatrimonioService = tipoPatrimonioService;
            _mapper = mapper;
        }

        // GET: TipopatrimonioController
        public ActionResult Index()
        {
            var listaTipopatrimonio = _tipoPatrimonioService.ObterTodos();
            var listaTipopatrimonioModel = _mapper.Map<List<TipopatrimonioModel>>(listaTipopatrimonio);
            return View(listaTipopatrimonioModel);
        }

        // GET: TipopatrimonioController/Details/5
        public ActionResult Details(int id)
        {
            Tipopatrimonio tipoPatrimonio = _tipoPatrimonioService.Obter(id);
            TipopatrimonioModel tipoPatrimonioModel = _mapper.Map<TipopatrimonioModel>(tipoPatrimonio);
            return View(tipoPatrimonioModel);
        }

        // GET: TipopatrimonioController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: TipopatrimonioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipopatrimonioModel tipoPatrimonioModel)
        {
            if (ModelState.IsValid)
            {
                var tipoPatrimonio = _mapper.Map<Tipopatrimonio>(tipoPatrimonioModel);
                _tipoPatrimonioService.Inserir(tipoPatrimonio);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipopatrimonioController/Edit/5
        public ActionResult Edit(int id)
        {
            Tipopatrimonio tipoPatrimonio = _tipoPatrimonioService.Obter(id);
            TipopatrimonioModel tipoPatrimonioModel = _mapper.Map<TipopatrimonioModel>(tipoPatrimonio);
            return View(tipoPatrimonioModel);
        }

        // POST: TipopatrimonioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipopatrimonioModel tipoPatrimonioModel)
        {
            if (ModelState.IsValid)
            {
                var tipoPatrimonio = _mapper.Map<Tipopatrimonio>(tipoPatrimonioModel);
                _tipoPatrimonioService.Editar(tipoPatrimonio);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipopatrimonioController/Delete/5
        public ActionResult Delete(int id)
        {
            Tipopatrimonio tipoPatrimonio = _tipoPatrimonioService.Obter(id);
            TipopatrimonioModel tipoPatrimonioModel = _mapper.Map<TipopatrimonioModel>(tipoPatrimonio);
            return View(tipoPatrimonioModel);
        }



        // POST: TipopatrimonioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipopatrimonioModel tipoPatrimonio)
        {
            _tipoPatrimonioService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
