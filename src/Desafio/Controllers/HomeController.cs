using System.Web.Mvc;
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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Projeto para controle de adoção de animais.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Bruno Henrique Belvedere";
            return View();
        }
    }
}