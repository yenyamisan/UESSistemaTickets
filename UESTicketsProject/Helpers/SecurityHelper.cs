using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UESTicketsProject.Helpers
{
    public static class SecurityHelper
    {
        public static string ToBase64(this string text)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string FromBase64(this string encodedText)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(encodedText);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}