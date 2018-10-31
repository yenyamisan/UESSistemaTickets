using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESTicketsProject.Data.Entities
{
    public abstract class CatalogEntityBase:EntityBase
    {
        public string Nombre { get; set; }
    }
}
