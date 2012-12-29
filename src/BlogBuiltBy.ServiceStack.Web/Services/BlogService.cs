using System.Collections.Generic;
using BlogBuiltBy.ServiceStack.Web.Dtos;
using BlogBuiltBy.ServiceStack.Web.Extensions;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace BlogBuiltBy.ServiceStack.Web.Services
{
    public class BlogService : Service
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof (BlogService));

        public List<Blog> Get(Blogs blogs)
        {
            Logger.Debug("Getting blogs");

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
            Logger.DebugFormat("Creating blog with name '{0}'", blog.Name);

            Db.Insert(blog);
            blog.Id = Db.GetLastInsertId();
            Logger.DebugFormat("Created a new blog with a id of '{0}'", blog.Id);

            return blog;
        }

        public object Put(Blog blog)
        {
            Logger.DebugFormat("Updating blog with a id of '{0}'", blog.Id);
            Db.Update(blog, b => b.Id == blog.Id);
            Logger.DebugFormat("Blog with Id '{0}' successfully updated", blog.Id);

            return blog;
        }

        public DeleteBlogResponse Any(DeleteBlog blog)
        {
            if (Db.Scalar<int>("Select count(*) From Blog Where Id = {0}", blog.Id) == 0)
            {
                Logger.WarnFormat("Cannot delete Blog with id of '{0}' because it doesn't exists in the database", blog.Id);

                return new DeleteBlogResponse
                    {
                        IsSuccessful = false,
                        Message = string.Format("No blog exists with an Id of {0}", blog.Id)
                    };
            }

            Db.DeleteById<Blog>(blog.Id);
            Logger.DebugFormat("Blog with id of '{0}' was deleted", blog.Id);

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