using System;
using System.Web.Mvc;
using Desafio.Contracts;
using Desafio.Services.Adopter;

namespace Desafio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdopterService _adopterService;

        public HomeController(IAdopterService service)
        {
            _adopterService = service;
        }
        public HomeController()
        {

        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}