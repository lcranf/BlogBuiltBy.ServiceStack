using System.Collections.Generic;
using BlogBuiltBy.ServiceStack.Web.Dtos;
using BlogBuiltBy.ServiceStack.Web.Extensions;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace BlogBuiltBy.ServiceStack.Web.Services
{
    public class BlogService : Service
    {
        public List<Blog> Get(Blogs blogs)
        {
            return blogs.Ids.IsNullOrEmpty()
                       ? Db.Select<Blog>()
                       : Db.GetByIds<Blog>(blogs.Ids);
        }

        public object Post(Blog blog)
        {
            Db.Insert(blog);
            blog.Id = Db.GetLastInsertId();
            return blog;
        }

        public object Put(Blog blog)
        {
            Db.Update(blog, b => b.Id == blog.Id);
            return blog;
        }

        public void Delete(Blogs blogs)
        {
            Db.DeleteByIds<Blog>(blogs.Ids);
        }

        public void Delete(Blog blog)
        {
            Db.DeleteById<Blog>(blog.Id);
        }
    }
}