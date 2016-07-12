using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestCI
{
    public partial class Page : System.Web.UI.Page
    {
        string NoUseString = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData gd = new GetData();
            testLable.InnerText = gd.GetMessage();
        }
    }
}