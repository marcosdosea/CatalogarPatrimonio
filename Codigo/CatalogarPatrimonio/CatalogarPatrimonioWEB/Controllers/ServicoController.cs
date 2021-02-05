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
    public class ServicoController : Controller
    {
        IServicoService _servicoService;
        IMapper _mapper;

        public ServicoController(IServicoService servicoService, IMapper mapper)
        {
            _servicoService = servicoService;
            _mapper = mapper;
        }

        // GET: ServicoController
        public ActionResult Index()
        {
            var listaServico = _servicoService.ObterTodos();
            var listaServicoModel = _mapper.Map<List<ServicoModel>>(listaServico);
            return View(listaServicoModel);
        }

        // GET: ServicoController/Details/5
        public ActionResult Details(int id)
        {
            Servico servico = _servicoService.Obter(id);
            ServicoModel servicoModel = _mapper.Map<ServicoModel>(servico);
            return View(servicoModel);
        }

        // GET: ServicoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicoModel servicoModel)
        {
            if (ModelState.IsValid)
            {
                var servico = _mapper.Map<Servico>(servicoModel);
                _servicoService.Inserir(servico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ServicoController/Edit/5
        public ActionResult Edit(int id)
        {
            Servico servico = _servicoService.Obter(id);
            ServicoModel servicoModel = _mapper.Map<ServicoModel>(servico);
            return View(servicoModel);
        }

        // POST: ServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServicoModel servicoModel)
        {
            if (ModelState.IsValid)
            {
                var servico = _mapper.Map<Servico>(servicoModel);
                _servicoService.Editar(servico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ServicoController/Delete/5
        public ActionResult Delete(int id)
        {
            Servico servico = _servicoService.Obter(id);
            ServicoModel servicoModel = _mapper.Map<ServicoModel>(servico);
            return View(servicoModel);
        }

        // POST: ServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ServicoModel servico)
        {
            _servicoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
