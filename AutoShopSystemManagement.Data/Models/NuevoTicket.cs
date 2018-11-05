using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESTicketsProject.Data.Entities;

namespace UESTicketsProject.Data.Models
{
    public class NuevoTicket
    {
        public Ticket Ticket { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Estatus> Estatuses { get; set; }
        public List<Prioridad> Prioridades { get; set; }
        public int ReporterId { get; set; }
        public Dictionary<int, string> TipoTicket { get; set; }
    }
}
