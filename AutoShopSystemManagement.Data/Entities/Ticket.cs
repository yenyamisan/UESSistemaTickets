using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESTicketsProject.Data.Entities
{
    [Table("Ticket")]
    public class Ticket:EntityBase
    {
        public int UsuarioReporter { get; set; }
        public int? UsuarioAsignado { get; set; }
        public int PrioridadId { get; set; }
        public int EstadoActualId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }

        [ForeignKey("UsuarioReporter")]
        public virtual Usuario Reporter { get; set; }

        [ForeignKey("UsuarioAsignado")]
        public virtual Usuario Assignee { get; set; }
        [ForeignKey("PrioridadId")]
        public virtual Prioridad Prioridad { get; set; }
    }
}
