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
            return View();
        }

        public JsonResult GetAll()
        {
            var result = _adopterService.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get(string adopterID)
        {
            var result = _adopterService.Get(Guid.Parse(adopterID));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(AdopterContract adopter)
        {
            var result = _adopterService.Add(adopter);
            return Json(result);
        }

        public JsonResult Edit(AdopterContract adopter)
        {
            var result = _adopterService.Edit(adopter);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Remove(string adopterID)
        {
            var result = _adopterService.Delete(Guid.Parse(adopterID));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}