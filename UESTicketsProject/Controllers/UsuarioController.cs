using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UESTicketsProject.Data.Entities;
using UESTicketsProject.Data.Models;
using UESTicketsProject.Data.Repositories.Interfaces;
using UESTicketsProject.Data.Services;

namespace UESTicketsProject.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEstatusesRepository _estatusesRepository;
        private readonly IPrioridadRepository _prioridadRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketService _ticketService;

        public UsuarioController(IUsuarioRepository usuarioRepository,ITicketRepository ticketRepository,IEstatusesRepository estatusesRepository, IPrioridadRepository prioridadRepository,ITicketService ticketService)
        {
            _usuarioRepository = usuarioRepository;
            _estatusesRepository = estatusesRepository;
            _prioridadRepository = prioridadRepository;
            _ticketService = ticketService;
            _ticketRepository = ticketRepository;
        }
        // GET: Usuario
        public ActionResult CrearTicket()
        {
            var model = new NuevoTicket
            {
                Estatuses = _estatusesRepository.GetAll().ToList(),
                Prioridades = _prioridadRepository.GetAll().ToList(),
                Usuarios = _usuarioRepository.GetAll().ToList()
            };
            return View(model);
        }

        public ActionResult CrearTicketResponse(NuevoTicket model)
        {
            _ticketService.CreatNewTicket(model);
            return RedirectToAction("ListarTickets");
        }

        public ActionResult ListarTickets()
        {
            var model = _ticketRepository.GetAll().ToList();
            return View(model);
        }

    }
}