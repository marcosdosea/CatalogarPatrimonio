using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class TipomaterialController : Controller
    {
        ITipomaterialService _tipoMaterialService;
        IMapper _mapper;

        // private readonly ITipopatrimonio tipoMaterial;
        public TipomaterialController(ITipomaterialService tipoMaterialService, IMapper mapper)
        {
            _tipoMaterialService = tipoMaterialService;
            _mapper = mapper;
        }

        // GET: TipomaterialController
        public ActionResult Index()
        {
            var listaTipomaterial = _tipoMaterialService.ObterTodos();
            var listaTipomaterialModel = _mapper.Map<List<TipomaterialModel>>(listaTipomaterial);
            return View(listaTipomaterialModel);
        }

        // GET: TipomaterialController/Details/5
        public ActionResult Details(int id)
        {
            Tipomaterial tipoMaterial = _tipoMaterialService.Obter(id);
            TipomaterialModel tipoMaterialModel = _mapper.Map<TipomaterialModel>(tipoMaterial);
            return View(tipoMaterialModel);
        }

        // GET: TipomaterialController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipomaterialController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipomaterialModel tipoMaterialModel)
        {
            if (ModelState.IsValid)
            {
                var tipoMaterial = _mapper.Map<Tipomaterial>(tipoMaterialModel);
                _tipoMaterialService.Inserir(tipoMaterial);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipomaterialController/Edit/5
        public ActionResult Edit(int id)
        {
            Tipomaterial tipoMaterial = _tipoMaterialService.Obter(id);
            TipomaterialModel tipoMaterialModel = _mapper.Map<TipomaterialModel>(tipoMaterial);
            return View(tipoMaterialModel);
        }

        // POST: TipomaterialController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipomaterialModel tipoMaterialModel)
        {
            if (ModelState.IsValid)
            {
                var tipoMaterial = _mapper.Map<Tipomaterial>(tipoMaterialModel);
                _tipoMaterialService.Editar(tipoMaterial);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipomaterialController/Delete/5
        public ActionResult Delete(int id)
        {
            Tipomaterial tipoMaterial = _tipoMaterialService.Obter(id);
            TipomaterialModel tipoMaterialModel = _mapper.Map<TipomaterialModel>(tipoMaterial);
            return View(tipoMaterialModel);
        }

        // POST: TipomaterialController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipomaterialModel tipoMaterial)
        {
            _tipoMaterialService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
