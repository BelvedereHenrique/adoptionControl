using System;
using System.Web.Mvc;
using Desafio.Services.Adoption;

namespace Desafio.Controllers
{
    public class AdoptionsController : Controller
    {
        private readonly IAdoptionService _adoptionService;

        public AdoptionsController(IAdoptionService adoptionService)
        {
            _adoptionService = adoptionService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFreeAnimals()
        {
            var result = _adoptionService.GetFreeAnimals();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var result = _adoptionService.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Adopt(Guid adopterId, Guid animalId)
        {
            var result = _adoptionService.Adopt(adopterId, animalId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveAdoption(Guid adoptionId)
        {
            var result = _adoptionService.CancelAdoption(adoptionId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}