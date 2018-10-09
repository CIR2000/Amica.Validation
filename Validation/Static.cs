using System;
using System.Collections.Generic;
using System.Text;

namespace Amica.Validation
{
    public static class Static
    {
        public static string MailRegex => @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    }
}
