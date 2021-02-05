using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class AdicionarGestorController : Controller
    {
        IAdicionarGestorService _gestorService;
        IMapper _mapper;
        // GET: AdicionarGestorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdicionarGestorController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = _gestorService.Obter(id);
            AdicionarGestorModel gestorModel = _mapper.Map<AdicionarGestorModel>(pessoa);
            return View(gestorModel);
        }

        // GET: AdicionarGestorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdicionarGestorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdicionarGestorModel adicionarGestorModel)
        {
            if (ModelState.IsValid)
            {
                var gestor = _mapper.Map<Pessoa>(adicionarGestorModel);
                _gestorService.Inserir(gestor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AdicionarGestorController/Edit/5
    }

        // POST: AdicionarGestorController/Edit/5

        // GET: AdicionarGestorController/Delete/5

        // POST: AdicionarGestorController/Delete/5
}
