using System;
using System.Net;
using BlogBuiltBy.ServiceStack.Web.Dtos;
using ServiceStack.Common.Web;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace BlogBuiltBy.ServiceStack.Web.Services
{
    public class PostService : Service
    {
        public PostsResponse Any(Posts posts)
        {
            return new PostsResponse
                {
                    IsSuccessful = true,
                    Posts = Db.Select<Post>(p => p.BlogId == posts.BlogId),
                    Blog = Db.GetById<Blog>(posts.BlogId)
                };
        }

        public object Get(Post post)
        {
            var entity = Db.SingleOrDefault<Post>("Id = {0}", post.Id);

            if (entity == null)
            {
                throw new HttpError(HttpStatusCode.NotFound, "NotFound");
            }

            return entity;
        }

        public object Post(Post post)
        {
            post.CreatedOn = DateTime.Now;

            Db.Insert(post);
            post.Id = Db.GetLastInsertId();

            return post;
        }

        public object Put(Post post)
        {
            Db.UpdateOnly(post,
                          ev => ev.Update(new[] {"Title", "Message"}).Where(p => p.Id == post.Id));

            return post;
        }

        public DeletePostResponse Delete(Post post)
        {
            Db.DeleteByIds<Post>(new [] { post.Id });

            return new DeletePostResponse
                {
                    IsSuccessful = true,
                    Message = string.Format("Post with Id '{0}' was sucessfully deleted.", post.Id),
                    RowsAffected = 1
                };
        }
    }
}