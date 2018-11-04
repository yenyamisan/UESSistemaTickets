using UESTicketsProject.Data.Entities;
using UESTicketsProject.Models;

namespace UESTicketsProject.Services.Interfaces
{
    public interface ILoginService
    {
        bool Login(LoginModel model, out Usuario usuario);
    }
}