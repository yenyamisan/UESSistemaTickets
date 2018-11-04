using System.Collections.Generic;
using UESTicketsProject.Data.Entities;

namespace UESTicketsProject.Data.Repositories.Interfaces
{
    public interface ITicketRepository:IRepository<Ticket>
    {
        List<Ticket> TicketsByUser(int userId);
    }
}