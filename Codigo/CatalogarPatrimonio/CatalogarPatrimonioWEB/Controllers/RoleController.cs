using Microsoft.AspNetCore.Mvc;
using Core.Service;
using Core;
using AutoMapper;
using System.Collections.Generic;
using CatalogarPatrimonioWEB.Models;

namespace CatalogarPatrimonioWEB.Controllers
{
    public class RoleController : Controller
    {
        IRoleService _roleService;
        IMapper _mapper;
        
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        //GET: Role
        public ActionResult RoleList()
        {
            var roleList = _roleService.ObterTodos();
            var listaRoleList = _mapper.Map<List<AspnetrolesModel>>(roleList);
            return View(roleList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aspnetroles aspnetrolesModel)
        {
            if (ModelState.IsValid)
            {
                var aspnetroles = _mapper.Map<Aspnetroles>(aspnetrolesModel);
                _roleService.Inserir(aspnetroles);
            }
            return RedirectToAction(nameof(RoleList));
        }    
    }
}
