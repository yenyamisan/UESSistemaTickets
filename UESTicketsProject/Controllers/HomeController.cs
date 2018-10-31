using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UESTicketsProject.Data.Repositories.Interfaces;

namespace UESTicketsProject.Controllers
{
    public class HomeController : Controller
    {
        private IRolRepository _rolRepository;
        private IDepartamentoRepository _departamentoRepository;
        public HomeController(IRolRepository rolRepository, IDepartamentoRepository departamentoRepository)
        {
            _rolRepository = rolRepository;
            _departamentoRepository = departamentoRepository;
        }
        public ActionResult Index()
        {
            var roles = _rolRepository.GetAll().ToList();
            var departamentos = _departamentoRepository.GetAll().ToList();
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