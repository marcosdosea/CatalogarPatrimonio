using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class TransferenciaMaterialController : Controller
    {
        //        ITransferenciamaterialService _transferenciaMaterialService;
        //        IMapper _mapper;

        //        private readonly ITransferenciaMaterialService transferenciaMaterialService;

        //        public TransferenciaMaterialController(ITransferenciamaterialService transferenciaMaterialService, IMapper mapper)
        //        {
        //            _transferenciaMaterialService = transferenciaMaterialService;
        //            _mapper = mapper;
        //        }

        //        GET: TransferenciaMaterialController
        //        public ActionResult Index()
        //        {
        //            var listaTransferenciaMaterial = _transferenciaMaterialService.ObterTodos();
        //            var listaTransferenciaMaterialModel = _mapper.Map<List<TransferenciamaterialModel>>(listaTransferenciaMaterial);
        //            return View(listaTransferenciaMaterialModel);
        //        }

        //        GET: TransferenciaMaterialController/Details/5
        //		public ActionResult Details(int idMaterial, int idTransferencia)
        //        {
        //            Transferenciamaterial transferenciaMaterial = _transferenciaMaterialService.Obter(idMaterial, IdTransferencia);
        //            TransferenciamaterialModel transferenciaMaterialModel = _mapper.Map<TransferenciamaterialModel>(transferenciaMaterial);
        //            return View(transferenciaMaterialModel);
        //        }

        //        GET: TransferenciaMaterialController/Create
        //        public ActionResult Create()
        //        {
        //            return View();
        //        }

        //        POST: TransferenciaMaterialController/Create
        //       [HttpPost]
        //       [ValidateAntiForgeryToken]
        //        public ActionResult Create(TransferenciamaterialModel transferenciaMaterialModel)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                var transferenciaMaterial = _mapper.Map<Transferenciamaterial>(transferenciaMaterialModel);
        //                _transferenciaMaterialService.Inserir(transferenciaMaterial);
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }

        //        GET: TransferenciaMaterialController/Edit/5
        //		public ActionResult Edit(int id)
        //        {
        //            Transferenciamaterial transferenciaMaterial = _transferenciaMaterialService.Obter(id);
        //            TransferenciamaterialModel transferenciaMaterialModel = _mapper.Map<TransferenciamaterialModel>(transferenciaMaterial);
        //            return View(transferenciaMaterialModel);
        //        }

        //        POST: TransferenciaMaterialController/Edit/5
        //		[HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Edit(int id, TransferenciamaterialModel transferenciaMaterialModel)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                var transferenciaMaterial = _mapper.Map<TransferenciaMaterial>(transferenciaMaterialModel);
        //                _transferenciaMaterialService.Editar(transferenciaMaterial);
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }

        //        GET: TransferenciaMaterialController/Delete/5
        //		public ActionResult Delete(int id)
        //        {
        //            Transferenciamaterial transferenciaMaterial = _transferenciaMaterialService.Obter(id);
        //            TransferenciamaterialModel transferenciaMaterialModel = _mapper.Map<TransferenciamaterialModel>(transferenciaMaterial);
        //            return View(transferenciaMaterialModel);
        //        }

        //        POST: TransferenciaMaterialController/Delete/5
        //		[HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Delete(int id, TransferenciamaterialModel transferenciaMaterial)
        //        {
        //            _transferenciaMaterialService.Remover(id);
        //            return RedirectToAction(nameof(Index));
        //        }
    }
}
