using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class EntradaController : Controller
    {
        IEntrada _entrada;
        IMapper _mapper;

        // private readonly IEntrada entrada;
        public EntradaController(IEntrada entrada, IMapper mapper)
        {
            _entradaService = entradaService;
            _mapper = mapper;
        }

        // GET: EntradaController
        public ActionResult Index()
        {
            var listaentrada = _entrada.ObterTodos();
            var listaentradaModel = _mapper.Map<List<EntradaModel>>(listaentrada);
            return View(listaentradaModel);
        }

        // GET: EntradaController/Details/5
        public ActionResult Details(int id)
        {
            Entrada entrada = _entrada.Obter(id);
            EntradaModel entradaModel = _mapper.Map<EntradaModel>(entrada);
            return View(entradaModel);
        }

        // GET: EntradaController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: EntradaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntradaModel entradaModel)
        {
            if (ModelState.IsValid)
            {
                var entrada = _mapper.Map<Entrada>(entradaModel);
                _entrada.Inserir(entrada);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EntradaController/Edit/5
        public ActionResult Edit(int id)
        {
            Entrada entrada = _entrada.Obter(id);
            EntradaModel entradaModel = _mapper.Map<EntradaModel>(entrada);
            return View(entradaModel);
        }

        // POST: EntradaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EntradaModel entradaModel)
        {
            if (ModelState.IsValid)
            {
                var entrada = _mapper.Map<Entrada>(entradaModel);
                _entrada.Editar(entrada);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EntradaController/Delete/5
        public ActionResult Delete(int id)
        {
            Entrada entrada = _entrada.Obter(id);
            EntradaModel entradaModel = _mapper.Map<EntradaModel>(entrada);
            return View(entradaModel);
        }



        // POST: EntradaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EntradaModel entrada)
        {
            _entrada.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
