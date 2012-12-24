using System;
using System.Collections.Generic;
using BlogBuiltBy.ServiceStack.Web.Dtos;
using ServiceStack.OrmLite;

namespace BlogBuiltBy.ServiceStack.Web.Repositories
{
    public class PostRepository : IPostRepository
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public List<Post> FindPostsByBlogId(long blogId)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                return db.Select<Post>(p => p.BlogId == blogId);
            }
        }

        public Post FindById(long id)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                return db.GetById<Post>(id);
            }
        }

        public Post Create(Post post)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                post.CreatedOn = DateTime.Now;
                db.Insert(post);
                post.Id = db.GetLastInsertId();
            }

            return post;
        }

        public Post Update(Post post)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.UpdateOnly(post,
                    ev => ev.Update(new[] {"Title", "Message"}).Where(p => p.Id == post.Id));
            }

            return post;
        }

        public void Delete(long id)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.DeleteById<Post>(id);
            }
        }
    }
}