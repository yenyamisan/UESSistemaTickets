using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UESTicketsProject.Helpers
{
    public static class SessionHelper
    {
        public static int GetUserId()
        {
            var uId=HttpContext.Current.Session.Contents ["UId"];
            if(uId!=null && !string.IsNullOrEmpty(uId.ToString()))
                return int.Parse(uId.ToString().FromBase64());
            return 0;
        }
    }
}