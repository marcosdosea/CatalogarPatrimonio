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
    public class TipoServicoController : Controller
    {
        ITipoServicoService _tiposervicoService;
        IMapper _mapper;

        // private readonly IEmpresa empresa;
        public TipoServicoController(ITipoServicoService tiposervicoService, IMapper mapper)
        {
            _tiposervicoService = tiposervicoService;
            _mapper = mapper;
        }

        // GET: TipoServicoController
        public ActionResult Index()
        {
            var listaTipoServico = _tiposervicoService.ObterTodos();
            var listaTipoServicoModel = _mapper.Map<List<TipoServicoModel>>(listaTipoServico);
            return View(listaTipoServicoModel);
        }

        // GET: TipoServicoController/Details/5
        public ActionResult Details(int id)
        {
            TipoServico tiposervico = _tiposervicoService.Obter(id);
            TipoServicoModel tiposervicoModel = _mapper.Map<TipoServicoModel>(tiposervico);
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
        public ActionResult Create(TipoServicoModel tiposervicoModel)
        {
            if (ModelState.IsValid)
            {
                var tiposervico = _mapper.Map<TipoServico>(tiposervicoModel);
                _tiposervicoService.Inserir(tiposervico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipoServicoController/Edit/5
        public ActionResult Edit(int id)
        {
            TipoServico tiposervico = _tiposervicoService.Obter(id);
            TipoServicoModel tiposervicoModel = _mapper.Map<TipoServicoModel>(tiposervico);
            return View(tiposervicoModel);
        }

        // POST: TipoServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoServicoModel tiposervicoModel)
        {
            if (ModelState.IsValid)
            {
                var tiposervico = _mapper.Map<TipoServico>(tiposervicoModel);
                _tiposervicoService.Editar(tiposervico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipoServicoController/Delete/5
        public ActionResult Delete(int id)
        {
            TipoServico tiposervico = _tiposervicoService.Obter(id);
            TipoServicoModel tiposervicoModel = _mapper.Map<TipoServicoModel>(tiposervico);
            return View(tiposervicoModel);
        }



        // POST: TipoServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipoServicoModel tiposervico)
        {
            _tiposervicoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
