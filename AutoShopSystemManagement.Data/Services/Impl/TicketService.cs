using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESTicketsProject.Data.Models;
using UESTicketsProject.Data.Repositories.Interfaces;

namespace UESTicketsProject.Data.Services.Impl
{
    public class TicketService:ITicketService
    {
        private readonly ITicketRepository _iTicketRepository;
        private readonly IPrioridadRepository _prioridadRepository;
        private readonly IEstatusesRepository _estatusesRepository;

        public TicketService(ITicketRepository iTicketRepository,IPrioridadRepository prioridadRepository,IEstatusesRepository estatusesRepository)
        {
            _iTicketRepository = iTicketRepository;
            _prioridadRepository = prioridadRepository;
            _estatusesRepository = estatusesRepository;
        }
        public void CreatNewTicket(NuevoTicket model)
        {
            model.Ticket.EstadoActualId = 1;
            model.Ticket.FechaCreacion = DateTime.Now;
            _iTicketRepository.Save(model.Ticket);
        }
    }
}
