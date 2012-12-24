using System.Collections.Generic;
using BlogBuiltBy.ServiceStack.Web.Dtos;
using BlogBuiltBy.ServiceStack.Web.Repositories;
using ServiceStack.ServiceInterface;

namespace BlogBuiltBy.ServiceStack.Web.Services
{
    public class PostService : Service
    {
        public IPostRepository PostRepository { get; set; }

        public List<Post> Any(Posts posts)
        {
            return PostRepository.FindPostsByBlogId(posts.BlogId);
        }

        public object Get(Post post)
        {
            return PostRepository.FindById(post.Id);
        }

        public object Post(Post post)
        {
            return PostRepository.Create(post);
        }

        public object Put(Post post)
        {
            return PostRepository.Update(post);
        }

        public void Delete(Post post)
        {
            PostRepository.Delete(post.Id);
        }
}
}