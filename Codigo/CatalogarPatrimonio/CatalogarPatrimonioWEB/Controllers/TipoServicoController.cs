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
    public class TiposervicoController : Controller
    {
        ITiposervicoService _tiposervicoService;
        IMapper _mapper;

        // private readonly IEmpresa empresa;
        public TiposervicoController(ITiposervicoService tiposervicoService, IMapper mapper)
        {
            _tiposervicoService = tiposervicoService;
            _mapper = mapper;
        }

        // GET: TipoServicoController
        public ActionResult Index()
        {
            var listaTiposervico = _tiposervicoService.ObterTodos();
            var listaTiposervicoModel = _mapper.Map<List<TiposervicoModel>>(listaTiposervico);
            return View(listaTiposervicoModel);
        }

        // GET: TipoServicoController/Details/5
        public ActionResult Details(int id)
        {
            TipoServico tiposervico = _tiposervicoService.Obter(id);
            TiposervicoModel tiposervicoModel = _mapper.Map<TiposervicoModel>(tiposervico);
            return View(tiposervicoModel);
        }

        // GET: TipoServicoController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: TipoServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TiposervicoModel tiposervicoModel)
        {
            if (ModelState.IsValid)
            {
                var tiposervico = _mapper.Map<TipoServico>(tiposervicoModel);
                _tiposervicoService.Inserir(tiposervico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TiposervicoController/Edit/5
        public ActionResult Edit(int id)
        {
            TipoServico tiposervico = _tiposervicoService.Obter(id);
            TiposervicoModel tiposervicoModel = _mapper.Map<TiposervicoModel>(tiposervico);
            return View(tiposervicoModel);
        }

        // POST: TiposervicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TiposervicoModel tiposervicoModel)
        {
            if (ModelState.IsValid)
            {
                var tiposervico = _mapper.Map<TipoServico>(tiposervicoModel);
                _tiposervicoService.Editar(tiposervico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TiposervicoController/Delete/5
        public ActionResult Delete(int id)
        {
            TipoServico tiposervico = _tiposervicoService.Obter(id);
            TiposervicoModel tiposervicoModel = _mapper.Map<TiposervicoModel>(tiposervico);
            return View(tiposervicoModel);
        }



        // POST: TiposervicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TiposervicoModel tiposervico)
        {
            _tiposervicoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
