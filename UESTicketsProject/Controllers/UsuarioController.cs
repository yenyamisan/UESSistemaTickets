using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UESTicketsProject.Data.Entities;
using UESTicketsProject.Data.Models;
using UESTicketsProject.Data.Repositories.Interfaces;
using UESTicketsProject.Data.Services;
using UESTicketsProject.Filters;
using UESTicketsProject.Helpers;
using UESTicketsProject.Models;

namespace UESTicketsProject.Controllers
{
    [UserValiationFilter]
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

        public ActionResult Dashboard()
        {
            var usuario = _usuarioRepository.Get(int.Parse(Session["UId"].ToString().FromBase64()));
            var model = new UsuarioDashboardModel
            {
                Usuario = usuario,
                Tickets = _ticketRepository.TicketsByUser(usuario.Id)
            };
            return View(model);
        }

        public ActionResult CrearTicket()
        {
            var model = new NuevoTicket
            {
                Estatuses = _estatusesRepository.GetAll().ToList(),
                Prioridades = _prioridadRepository.GetAll().ToList(),
                Usuarios = _usuarioRepository.GetAll().ToList(),
                TipoTicket = DataHelpers.TipoTicket
            };
            return View(model);
        }

        public ActionResult CrearTicketResponse(NuevoTicket model)
        {
            model.ReporterId = SessionHelper.GetUserId();
            _ticketService.CreatNewTicket(model);
            return RedirectToAction("Dashboard");
        }


        public ActionResult ListarTickets(string tipo)
        {
            var usuario = _usuarioRepository.Get(int.Parse(Session["UId"].ToString().FromBase64()));
            var model = new UsuarioDashboardModel
            {
                Usuario = usuario
            };
            switch (tipo)
            {
                case "Abiertos":

                    model.Tickets = _ticketRepository.TicketsByUser(usuario.Id).Where(x => x.EstadoActualId == 1)
                        .ToList();
                    model.Estatus = "Abiertos";
                    break;

                case "Completados":

                    model.Tickets = _ticketRepository.TicketsByUser(usuario.Id).Where(x => x.EstadoActualId >3)
                        .ToList();
                    model.Estatus = "Completados";
                    break;
                case "Enprogreso":

                    model.Tickets = _ticketRepository.TicketsByUser(usuario.Id).Where(x => x.EstadoActualId ==2)
                        .ToList();
                    model.Estatus = "En progreso";
                    break;

                case "Pruebas":

                    model.Tickets = _ticketRepository.TicketsByUser(usuario.Id).Where(x => x.EstadoActualId == 3)
                        .ToList();
                    model.Estatus = "En pruebas";
                    break;
                default:

                    model.Tickets = _ticketRepository.TicketsByUser(usuario.Id).Where(x => x.EstadoActualId == 1)
                        .ToList();
                    model.Estatus = "Abiertos ";
                    break;
            }
            return View(model);
        }

        public ActionResult VerTicket(int id)
        {
            var model = new ViewTicketModel
            {
                Ticket = _ticketRepository.Get(id),
                Estatuses = _estatusesRepository.GetAll().ToList(),
                Usuarios = _usuarioRepository.GetAll().ToList(),
                Usuario =_usuarioRepository.Get(int.Parse(Session["UId"].ToString().FromBase64())),
                Prioridades = _prioridadRepository.GetAll().ToList()
            };
            return View(model);
        }

        public ActionResult ActualizarTicket(ViewTicketModel model)
        {
            _ticketRepository.ChangeTicketStatus(model.Ticket.Id,model.Ticket.EstadoActualId);
            return RedirectToAction("VerTicket",new{id=model.Ticket.Id});
        }
    }
}