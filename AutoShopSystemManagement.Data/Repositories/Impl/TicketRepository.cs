using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESTicketsProject.Data.Entities;
using UESTicketsProject.Data.Repositories.Interfaces;

namespace UESTicketsProject.Data.Repositories.Impl
{
    public class TicketRepository:Repository<Ticket>,ITicketRepository
    {
        public List<Ticket> TicketsByUser(int userId)
        {
            return context.Tickets.Where(x => x.UsuarioAsignado.HasValue && x.UsuarioAsignado.Value == userId).ToList();
        }

        public List<Ticket> TicketsReporterByUser(int userId)
        {
            return context.Tickets.Where(x => x.UsuarioReporter == userId).ToList();
        }
    }
}
