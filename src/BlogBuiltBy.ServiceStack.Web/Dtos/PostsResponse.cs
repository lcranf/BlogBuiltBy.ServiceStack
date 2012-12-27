using System.Collections.Generic;

namespace BlogBuiltBy.ServiceStack.Web.Dtos
{
    public class PostsResponse : ResponseBase
    {
        public List<Post> Posts { get; set; }
        public Blog Blog { get; set; }
    }
}