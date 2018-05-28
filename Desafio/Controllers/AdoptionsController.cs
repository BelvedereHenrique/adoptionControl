using System;
using System.Linq;
using System.Web.Mvc;
using Desafio.Contracts;
using Desafio.Services.Animal;
using Desafio.Services.Adopter;
using Desafio.Services.Adoption;

namespace Desafio.Controllers
{
    public class AdoptionsController : Controller
    {
        private readonly IAdoptionService _adoptionService;
        private readonly IAdopterService _adopterService;
        private readonly IAnimalService _animalService;

        public AdoptionsController(IAdoptionService adoptionService, IAdopterService adopterService, IAnimalService animalService)
        {
            _adoptionService = adoptionService;
            _adopterService = adopterService;
            _animalService = animalService;
        }

        public ActionResult Index()
        {
            return View(_adoptionService.GetAll().Result);
        }

        public ActionResult New()
        {
            ViewBag.Adopters = new SelectList(_adopterService.GetAll().Result, "ID", "Name");
            ViewBag.Animals = new SelectList(_animalService.GetAll().Result.Where(x => x.AdoptedBy == null).ToList(), "ID", "Name");
            return View();

        }

        [HttpPost]
        public ActionResult New(AdoptionContract adoption)
        {
            try
            {
                ViewBag.Animals = new SelectList(_adopterService.GetAll().Result, "ID", "Name");
                ViewBag.Dogs = new SelectList(_animalService.GetAll().Result.Where(x => x.AdoptedBy == null).ToList(), "ID", "Name");

                var adopterID = Request.Form["Adopters"];
                var animalID = Request.Form["Animals"];

                _adoptionService.Adopt(Guid.Parse(adopterID), Guid.Parse(animalID));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Remove(Guid id)
        {
            _adoptionService.CancelAdoption(id);
            return RedirectToAction("Index");
        }
    }
}