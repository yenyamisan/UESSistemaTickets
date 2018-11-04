using System;
using System.Linq;
using UESTicketsProject.Data.Entities;
using UESTicketsProject.Data.Repositories.Interfaces;

namespace UESTicketsProject.Data.Repositories.Impl
{
    public class UsuarioRepository:Repository<Usuario>,IUsuarioRepository
    {
        public Usuario GetByUserName(string username)
        {
            return context.Usuarios.SingleOrDefault(x => x.Alias.ToLower()==username.ToLower());
        }
    }
}
