using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace XiaZaiWZ.WebUI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //计算页面执行时间
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            Application["StartTime"] = System.DateTime.Now;
        }
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            //System.DateTime startTime = (System.DateTime)Application["StartTime"];
            //System.DateTime endTime = System.DateTime.Now;
            //System.TimeSpan ts = endTime - startTime;
            //Application["runtime"] = (Convert.ToDouble((ts.Milliseconds)) / 1000);
            //<%=Convert.ToString(Application["runtime"]) %>
        }
    }
}