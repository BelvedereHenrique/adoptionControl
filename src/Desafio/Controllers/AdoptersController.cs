using System;
using System.Web.Mvc;
using Desafio.Contracts;
using Desafio.Services.Adopter;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Desafio.Controllers
{
    public class AdoptersController : Controller
    {
        private readonly IAdopterService _adopterService;

        public AdoptersController(IAdopterService adopterService)
        {
            _adopterService = adopterService;
        }

        // GET: Adotpers
        public ActionResult Index()
        {
            var adopters = _adopterService.GetAll().Result;
            return View(adopters);
        }
        
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(AdopterContract adopter)
        {
            try
            {
                _adopterService.Add(adopter);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            return View(_adopterService.Get(Guid.Parse(id)).Result);
        }


        [HttpPost]
        public ActionResult Edit(string id, AdopterContract adopter)
        {
            try
            {
                _adopterService.Edit(adopter);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Remove(Guid id)
        {
            _adopterService.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}