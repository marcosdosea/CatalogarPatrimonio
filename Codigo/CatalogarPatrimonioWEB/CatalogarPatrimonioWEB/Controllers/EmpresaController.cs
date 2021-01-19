﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class EmpresaController : Controller
    {
        IEmpresa _empresa;
        IMapper _mapper;

        // private readonly IEmpresa empresa;
        public EmpresaController(IEmpresa empresa, IMapper mapper)
        {
            _empresaService = empresaService;
            _mapper = mapper;
        }

        // GET: EmpresaController
        public ActionResult Index()
        {
            var listaEmpresa = _empresa.ObterTodos();
            var listaEmpresaModel = _mapper.Map<List<EmpresaModel>>(listaEmpresa);
            return View(listaEmpresaModel);
        }

        // GET: EmpresaController/Details/5
        public ActionResult Details(int id)
        {
            Empresa empresa = _empresa.Obter(id);
            EmpresaModel empresaModel = _mapper.Map<EmpresaModel>(empresa);
            return View(empresaModel);
        }

        // GET: EmpresaController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: EmpresaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaModel empresaModel)
        {
            if (ModelState.IsValid)
            {
                var empresa = _mapper.Map<Empresa>(empresaModel);
                _empresa.Inserir(empresa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EmpresaController/Edit/5
        public ActionResult Edit(int id)
        {
            Empresa empresa = _empresa.Obter(id);
            EmpresaModel empresaModel = _mapper.Map<EmpresaModel>(empresa);
            return View(empresaModel);
        }

        // POST: EmpresaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmpresaModel empresaModel)
        {
            if (ModelState.IsValid)
            {
                var empresa = _mapper.Map<Empresa>(empresaModel);
                _empresa.Editar(empresa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EmpresaController/Delete/5
        public ActionResult Delete(int id)
        {
            Empresa empresa = _empresa.Obter(id);
            EmpresaModel empresaModel = _mapper.Map<EmpresaModel>(empresa);
            return View(empresaModel);
        }



        // POST: EmpresaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmpresaModel empresa)
        {
            _empresa.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
