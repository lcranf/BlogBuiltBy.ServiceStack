using System.Collections.Generic;
using System.Linq;
using BlogBuiltBy.ServiceStack.Web.Dtos;
using BlogBuiltBy.ServiceStack.Web.Extensions;
using BlogBuiltBy.ServiceStack.Web.Repositories;
using ServiceStack.ServiceInterface;

namespace BlogBuiltBy.ServiceStack.Web.Services
{
    public class BlogService : Service
    {
        public IBlogRepository Repository { get; set; }

        public List<Blog> Any(FindBlogsByIds query)
        {
            return query.Ids.IsNullOrEmpty()
                       ? Repository.GetAll().ToList()
                       : Repository.FindByIds(query.Ids).ToList();
        }

        public object Post(Blog blog)
        {
            return Repository.AddOrUpdate(blog);
        }

        public object Put(Blog blog)
        {
            return Post(blog);
        }

        public void Delete(FindBlogsByIds request)
        {
            Repository.Delete(request.Ids);
        }

        public void Delete(Blog blog)
        {
            Repository.Delete(new[] { blog.Id });
        }
    }
}