using ServiceStack.ServiceHost;

namespace BlogBuiltBy.ServiceStack.Web.Dtos
{
    [Route("/posts/{BlogId}")]
    public class Posts
    {
        public long BlogId { get; set; }
    }
}