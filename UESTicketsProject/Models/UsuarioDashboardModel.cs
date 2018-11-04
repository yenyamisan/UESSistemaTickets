using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UESTicketsProject.Data.Entities;

namespace UESTicketsProject.Models
{
    public class UsuarioDashboardModel
    {
        public Usuario Usuario { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}