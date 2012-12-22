using BlogBuiltBy.ServiceStack.Web.Repositories;
using BlogBuiltBy.ServiceStack.Web.Services;
using Funq;
using ServiceStack.WebHost.Endpoints;

namespace BlogBuiltBy.ServiceStack.Web.Infrastructure
{
    public class BlogAppHost : AppHostBase
    {
        public BlogAppHost()
            : base("Blog Web Services", typeof(BlogService).Assembly) { }

        public override void Configure(Container container)
        {
            container.RegisterAutoWiredAs<BlogRepository, IBlogRepository>();
        }
    }
}