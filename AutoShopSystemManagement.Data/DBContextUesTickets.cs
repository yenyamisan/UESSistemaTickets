
using System.Data.Entity;
using UESTicketsProject.Data.Entities;

namespace UESTicketsProject.Data
{
    public class DBContextUesTickets : DbContext
    {
        public DBContextUesTickets():base("UesConnectionString")
        {
        
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
