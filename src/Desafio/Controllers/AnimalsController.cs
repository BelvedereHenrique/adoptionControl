using System;
using System.Web.Mvc;
using Desafio.Contracts;
using Desafio.Services.Animal;

namespace Desafio.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly IAnimalService _animalService;
        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            var result = _animalService.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get(string animalID)
        {
            var result = _animalService.Get(Guid.Parse(animalID));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(AnimalContract animal)
        {
            var result = _animalService.Add(animal);
            return Json(result);
        }

        public JsonResult Edit(AnimalContract animal)
        {
            var result = _animalService.Edit(animal);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Remove(string animalID)
        {
            var result = _animalService.Delete(Guid.Parse(animalID));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}