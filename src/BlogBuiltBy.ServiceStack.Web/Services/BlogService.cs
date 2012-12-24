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

        public DeleteBlogsResponse Delete(Blogs blogs)
        {
            Db.DeleteByIds<Blog>(blogs.Ids);

            return new DeleteBlogsResponse
                {
                    IsSuccessful = true,
                    RowsAffected = blogs.Ids.Length,
                    Message = string.Format("{0} Blogs were successfully deleted.", blogs.Ids.Length)
                };
        }

        public DeleteBlogResponse Delete(Blog blog)
        {
            Db.DeleteById<Blog>(blog.Id);

            return new DeleteBlogResponse
                {
                    IsSuccessful = true,
                    RowsAffected = 1,
                    Message = string.Format("Blog with id of '{0}' was successfully deleted", blog.Id)
                };
        }
    }
}