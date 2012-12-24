using System.Collections.Generic;
using BlogBuiltBy.ServiceStack.Web.Dtos;

namespace BlogBuiltBy.ServiceStack.Web.Repositories
{
    public interface IPostRepository
    {
        List<Post> FindPostsByBlogId(long blogId);
        Post FindById(long id);
        Post Create(Post post);
        Post Update(Post post);
        void Delete(long id);
    }
}