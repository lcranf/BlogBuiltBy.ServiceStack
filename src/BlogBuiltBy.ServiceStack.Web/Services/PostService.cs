﻿using System.Collections.Generic;
using BlogBuiltBy.ServiceStack.Web.Dtos;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace BlogBuiltBy.ServiceStack.Web.Services
{
    public class PostService : Service
    {
        public List<Post> Any(Posts posts)
        {
            return Db.Select<Post>(p => p.BlogId == posts.BlogId);
        }

        public object Get(Post post)
        {
            return Db.GetById<Post>(post.Id);
        }

        public object Post(Post post)
        {
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

        public void Delete(Post post)
        {
            Db.DeleteById<Post>(post.Id);
        }
    }
}