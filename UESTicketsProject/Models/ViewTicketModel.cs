using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UESTicketsProject.Data.Entities;

namespace UESTicketsProject.Models
{
    public class ViewTicketModel
    {
        public Ticket Ticket { get; set; }
        public List<Estatus> Estatuses { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public Usuario Usuario { get; set; }
        public List<Prioridad> Prioridades { get; set; }
    }
}