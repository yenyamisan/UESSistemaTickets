using System.Collections.Generic;
using UESTicketsProject.Data.Entities;

namespace UESTicketsProject.Data.Repositories.Interfaces
{
    public interface ITicketRepository:IRepository<Ticket>
    {
        List<Ticket> TicketsByUser(int userId);
        List<Ticket> TicketsReporterByUser(int userId);
        void AssingUser(int userId, int ticketId);
        void ChangeTicketStatus(int ticketId, int newStatus);
    }
}