using System.Web;
using BlogBuiltBy.ServiceStack.Web.Dtos;
using BlogBuiltBy.ServiceStack.Web.Services;
using Funq;
using ServiceStack.Logging;
using ServiceStack.Logging.Log4Net;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.OrmLite;
using ServiceStack.Razor;
using ServiceStack.ServiceInterface.Admin;
using ServiceStack.WebHost.Endpoints;

namespace BlogBuiltBy.ServiceStack.Web.Infrastructure
{
    public class BlogAppHost : AppHostBase
    {
        public BlogAppHost()
            : base("Blog Web Services", typeof(BlogService).Assembly) { }

        public override void Configure(Container container)
        {
            SetupLoggingAndProfiling(container);
            SetupPlugins(container);
            SetupDatabase(container);
        }

        private void SetupLoggingAndProfiling(Container container)
        {
            LogManager.LogFactory = new Log4NetFactory(true);
        }

        private void SetupPlugins(Container container)
        {
            Plugins.Add(new RequestLogsFeature());
            Plugins.Add(new RazorFormat());
        }

        private void SetupDatabase(Container container)
        {
            var dbFactory = new OrmLiteConnectionFactory(
                HttpContext.Current.Server.MapPath("~/App_Data/blogdb.sqlite"), SqliteDialect.Provider)
                {
                    ConnectionFilter = con => new ProfiledDbConnection(con, Profiler.Current)
                };

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