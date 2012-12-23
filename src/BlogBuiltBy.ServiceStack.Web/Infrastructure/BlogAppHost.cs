using System.Web;
using BlogBuiltBy.ServiceStack.Web.Repositories;
using BlogBuiltBy.ServiceStack.Web.Services;
using Funq;
using ServiceStack.OrmLite;
using ServiceStack.WebHost.Endpoints;

namespace BlogBuiltBy.ServiceStack.Web.Infrastructure
{
    public class BlogAppHost : AppHostBase
    {
        public BlogAppHost()
            : base("Blog Web Services", typeof(BlogService).Assembly) { }

        public override void Configure(Container container)
        {
            var dbFactory = new OrmLiteConnectionFactory(
                HttpContext.Current.Server.MapPath("~/App_Data/blogdb.sqlite"), SqliteDialect.Provider);
            
            container.Register<IDbConnectionFactory>(dbFactory);
            container.RegisterAutoWiredAs<BlogRepository, IBlogRepository>()
                     .ReusedWithin(ReuseScope.Request);

        }
    }
}