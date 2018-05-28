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
            return View(_animalService.GetAll().Result);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(AnimalContract animal)
        {
            try
            {
                _animalService.Add(animal);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(Guid id)
        {
            return View(_animalService.Get(id).Result);
        }
        [HttpPost]
        public ActionResult Edit(string id, AnimalContract animal)
        {
            try
            {
                _animalService.Edit(animal);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            _animalService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}