using UESTicketsProject.Data.Models;

namespace UESTicketsProject.Data.Services
{
    public interface ITicketService
    {
        void CreatNewTicket(NuevoTicket model);
    }
}