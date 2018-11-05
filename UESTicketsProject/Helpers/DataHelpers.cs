using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UESTicketsProject.Helpers
{
    public static class DataHelpers
    {
        public static Dictionary<int,string> TipoTicket = new Dictionary<int,string>
        {
            {1, "Software"},
            {2,"Hardware" }
        };
    }
}