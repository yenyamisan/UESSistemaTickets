using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UESTicketsProject.Data.Entities;
using UESTicketsProject.Data.Models;
using UESTicketsProject.Data.Repositories.Interfaces;
using UESTicketsProject.Filters;
using UESTicketsProject.Helpers;
using UESTicketsProject.Models;

namespace UESTicketsProject.Controllers
{
    [AdminValiationFilter]
    public class AdminController : Controller
    {
        private IRolRepository _rolRepository;
        private IDepartamentoRepository _departamentoRepository;
        private IUsuarioRepository _usurioRepository;
        private readonly ITicketRepository _ticketRepository;

        public AdminController(IRolRepository rolRepository, IDepartamentoRepository departamentoRepository,IUsuarioRepository usurioRepository,ITicketRepository ticketRepository)
        {
            _rolRepository = rolRepository;
            _departamentoRepository = departamentoRepository;
            _usurioRepository = usurioRepository;
            _ticketRepository = ticketRepository;
        }

        public ActionResult Dashboard()
        {
            var usuario = _usurioRepository.Get(int.Parse(Session["UId"].ToString().FromBase64()));
            var model = new UsuarioDashboardModel
            {
                Usuario = usuario,
                Tickets = _ticketRepository.GetAll().ToList()
            };
            return View(model);
        }

        public ActionResult AsignarTicket(int ticketId)
        {
            var model = new NuevoTicket
            {
                Usuarios = _usurioRepository.GetAll().ToList(),
                Ticket = _ticketRepository.Get(ticketId)
            };
            return View(model);
        }

        public ActionResult AsignarTicketResponse(NuevoTicket model)
        {
            if(model.Ticket.UsuarioAsignado.HasValue)
                _ticketRepository.AssingUser(model.Ticket.UsuarioAsignado.Value,model.Ticket.Id);
            return RedirectToAction("Dashboard");
        }

        public ActionResult ListarTickets(string tipo)
        {
            var usuario = _usurioRepository.Get(int.Parse(Session["UId"].ToString().FromBase64()));
            var model = new UsuarioDashboardModel
            {
                Usuario = usuario
            };
            switch (tipo)
            {
                case "UnAssigned":

                    model.Tickets = _ticketRepository.GetAll().Where(x => x.Assignee==null)
                        .ToList();
                    model.Estatus = "Sin Asignar";
                    break;

                case "Completados":

                    model.Tickets = _ticketRepository.GetAll().Where(x => x.EstadoActualId > 3)
                        .ToList();
                    model.Estatus = "Completados";
                    break;
                case "Enprogreso":

                    model.Tickets = _ticketRepository.GetAll().Where(x => x.EstadoActualId == 2)
                        .ToList();
                    model.Estatus = "En progreso";
                    break;

                case "Pruebas":

                    model.Tickets = _ticketRepository.GetAll().Where(x => x.EstadoActualId == 3)
                        .ToList();
                    model.Estatus = "En pruebas";
                    break;
                default:

                    model.Tickets = _ticketRepository.GetAll().Where(x => x.EstadoActualId == 1)
                        .ToList();
                    model.Estatus = "Abiertos ";
                    break;
            }
            return View(model);
        }

        public ActionResult AgregarRol()
        {
            var model = new Rol();
            return View(model);
        }

        public ActionResult ListarRoles()
        {
            var model = _rolRepository.GetAll().ToList();
            return View(model);
        }

        public ActionResult CrearRol(Rol model)
        {
            _rolRepository.Save(model);
            return RedirectToAction("ListarRoles");
        }


        public ActionResult ListarDepartamentos()
        {
            var model = _departamentoRepository.GetAll().ToList();
            return View(model);
        }

        public ActionResult AgregarDepartamento()
        {
            var model = new Departamento();
            return View(model);
        }

        public ActionResult CrearDepartamento(Departamento model)
        {
            _departamentoRepository.Save(model);
            return RedirectToAction("ListarDepartamentos");

        }

        public ActionResult ListarUsuarios()
        {
            var model = _usurioRepository.GetAll().ToList();
            return View(model);
        }

        public ActionResult AgregarNuevoUsuario()
        {
            var model = new NuevoUsuario {
                Departamentos = _departamentoRepository.GetAll().ToList(),
                Roles = _rolRepository.GetAll().ToList()
            };
            return View(model);
        }

        public ActionResult CrearUsuario(NuevoUsuario model)
        {
            if (model?.Usuario == null) return RedirectToAction("AgregarNuevoUsuario");
            model.Usuario.Password = model.Usuario.Password.ToBase64();
            model.Usuario.Active = true;
            _usurioRepository.Save(model.Usuario);
            return RedirectToAction("ListarUsuarios");
        }
    }
}