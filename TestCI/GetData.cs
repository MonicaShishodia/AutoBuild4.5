using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCI
{
    public class GetData : IPrintMessage
    {
        public string GetMessage()
        {
            return "Welcome to ASP.Net";
        }
    }
}