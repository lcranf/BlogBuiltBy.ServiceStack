using System.Web;
using BlogBuiltBy.ServiceStack.Web.Dtos;
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
            SetupDatabase(container);
            RegisterRepositories(container);
        }

        private void SetupDatabase(Container container)
        {
            var dbFactory = new OrmLiteConnectionFactory(
                HttpContext.Current.Server.MapPath("~/App_Data/blogdb.sqlite"), SqliteDialect.Provider);
            CreateDatabase(dbFactory);

            container.Register<IDbConnectionFactory>(dbFactory);
        }

        private static void RegisterRepositories(Container container)
        {
            container.RegisterAutoWiredAs<BlogRepository, IBlogRepository>()
                     .ReusedWithin(ReuseScope.Request);
            container.RegisterAutoWiredAs<PostRepository, IPostRepository>()
                     .ReusedWithin(ReuseScope.Request);
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