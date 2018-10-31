using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESTicketsProject.Data.Entities;

namespace UESTicketsProject.Data.Models
{
    public class NuevoUsuario
    {
        public Usuario Usuario { get; set; }
        public List<Departamento> Departamentos { get; set; }
        public List<Rol> Roles { get; set; }
    }
}
