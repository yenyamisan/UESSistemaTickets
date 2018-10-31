using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESTicketsProject.Data.Entities
{
    [Table("Usuario")]
    public class Usuario:EntityBase
    {
        public int DepartamentoId { get; set; }
        public int RolId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        [ForeignKey("RolId")]
        public virtual Rol Rol { get; set; }
        [ForeignKey("DepartamentoId")]
        public virtual Departamento Departamento { get; set; }
    }
}
