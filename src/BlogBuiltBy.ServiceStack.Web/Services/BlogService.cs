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

        public object Get(Blog blog)
        {
            return Db.GetByIdOrDefault<Blog>(blog.Id);
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

        public DeleteBlogResponse Any(DeleteBlog blog)
        {
            if (Db.Scalar<int>("Select count(*) From Blog Where Id = {0}", blog.Id) == 0)
            {
                return new DeleteBlogResponse
                    {
                        IsSuccessful = false,
                        Message = string.Format("No blog exists with an Id of {0}", blog.Id)
                    };
            }

            Db.DeleteById<Blog>(blog.Id);

            return new DeleteBlogResponse
                {
                    Id = blog.Id,
                    IsSuccessful = true,
                    RowsAffected = 1,
                    Message = string.Format("Blog with id of '{0}' was successfully deleted", blog.Id)
                };
        }
    }
}