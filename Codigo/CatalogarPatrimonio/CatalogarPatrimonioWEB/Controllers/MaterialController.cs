using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using Core.DTO;
using CatalogarPatrimonioWEB.Models;
using System.Collections.Generic;
using Core.Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class MaterialController : Controller
    {
		IMaterialService _materialService;
		IMapper _mapper;
		ITipomaterialService _tipomaterialService;
 
		// private readonly IMaterialService materialService;

		public MaterialController(IMaterialService materialService, IMapper mapper, ITipomaterialService tipomaterialService)
		{
			_tipomaterialService = tipomaterialService;
			_materialService = materialService;
			_mapper = mapper;
		}

		// GET: MaterialController
		public ActionResult Index()
		{
			var listaMaterial = _materialService.ObterTodos();
			return View(listaMaterial);
		}

		// GET: MaterialController/Details/5
		public ActionResult Details(int id)
		{
			Material material = _materialService.Obter(id);
			MaterialModel materialModel = _mapper.Map<MaterialModel>(material);
			return View(materialModel);
		}

		// GET: MaterialController/Create
		public ActionResult Create()
		{
			IEnumerable<Tipomaterial> tipoMateriais = _tipomaterialService.ObterTodos();
			ViewBag.Tipos = new SelectList(tipoMateriais, "Id", "Nome", null);
			return View();
		}

		// POST: MaterialController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(MaterialModel materialModel)
		{
			if (ModelState.IsValid)
			{
				var material = _mapper.Map<Material>(materialModel);
				_materialService.Inserir(material);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: MaterialController/Edit/5
		public ActionResult Edit(int id)
		{

			IEnumerable<Tipomaterial> tipoMateriais = _tipomaterialService.ObterTodos();
			Material material = _materialService.Obter(id);
			MaterialModel materialModel = _mapper.Map<MaterialModel>(material);

			ViewBag.Tipos = new SelectList(tipoMateriais, "Id", "Nome", null);
			return View(materialModel);
		}

		// POST: MaterialController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, MaterialModel materialModel)
		{
			if (ModelState.IsValid)
			{
				var material = _mapper.Map<Material>(materialModel);
				_materialService.Editar(material);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: MaterialController/Delete/5
		public ActionResult Delete(int id)
		{
			Material material = _materialService.Obter(id);
			Tipomaterial tipoMaterial = _tipomaterialService.Obter(material.IdTipoMaterial);
			ViewBag.Tipos = tipoMaterial.Nome;

			MaterialModel materialModel = _mapper.Map<MaterialModel>(material);
			return View(materialModel);
		}

		// POST: MaterialController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, MaterialModel material)
		{
			_materialService.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
