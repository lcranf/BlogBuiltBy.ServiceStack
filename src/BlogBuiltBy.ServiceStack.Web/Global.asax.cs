using System;
using BlogBuiltBy.ServiceStack.Web.Infrastructure;
using ServiceStack.MiniProfiler;

namespace BlogBuiltBy.ServiceStack.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new BlogAppHost().Init();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.IsLocal)
                Profiler.Start();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            Profiler.Stop();
        }
    }
}