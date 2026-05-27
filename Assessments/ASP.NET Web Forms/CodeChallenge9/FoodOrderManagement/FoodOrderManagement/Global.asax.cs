using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace FoodOrderManagement
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["TotalVisitors"] = 0;
            Application["ActiveUsers"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();

            Application["TotalVisitors"] =
                Convert.ToInt32(Application["TotalVisitors"]) + 1;

            Application["ActiveUsers"] =
                Convert.ToInt32(Application["ActiveUsers"]) + 1;

            Application.UnLock();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();

            Application["ActiveUsers"] =
                Convert.ToInt32(Application["ActiveUsers"]) - 1;

            Application.UnLock();
        }
    }
}