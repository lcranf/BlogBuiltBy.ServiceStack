using System;
using BlogBuiltBy.ServiceStack.Web.Infrastructure;

namespace BlogBuiltBy.ServiceStack.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new BlogAppHost().Init();
        }
    }
}