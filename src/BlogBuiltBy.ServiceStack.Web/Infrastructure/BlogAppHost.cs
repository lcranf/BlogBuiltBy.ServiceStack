using System.Web;
using BlogBuiltBy.ServiceStack.Web.Dtos;
using BlogBuiltBy.ServiceStack.Web.Services;
using Funq;
using ServiceStack.Logging;
using ServiceStack.Logging.Log4Net;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.OrmLite;
using ServiceStack.Razor;
using ServiceStack.WebHost.Endpoints;

namespace BlogBuiltBy.ServiceStack.Web.Infrastructure
{
    public class BlogAppHost : AppHostBase
    {
        public BlogAppHost()
            : base("Blog Web Services", typeof(BlogService).Assembly) { }

        public override void Configure(Container container)
        {
            //TODO: configure logging
            LogManager.LogFactory = new Log4NetFactory(true);
            InstallPlugins(container);
            SetupDatabase(container);
        }

        private void InstallPlugins(Container container)
        {
            Plugins.Add(new RazorFormat());
        }

        private void SetupDatabase(Container container)
        {
            var dbFactory = new OrmLiteConnectionFactory(
                HttpContext.Current.Server.MapPath("~/App_Data/blogdb.sqlite"), SqliteDialect.Provider);
            CreateDatabase(dbFactory);

            container.Register<IDbConnectionFactory>(dbFactory);
        }

        private void CreateDatabase(OrmLiteConnectionFactory dbFactory)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                db.CreateTableIfNotExists<Blog>();
                db.CreateTableIfNotExists<Post>();
            }
        }
    }
}