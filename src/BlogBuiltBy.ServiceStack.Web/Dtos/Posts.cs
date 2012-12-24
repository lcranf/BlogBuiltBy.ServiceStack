using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace BlogBuiltBy.ServiceStack.Web.Dtos
{
    [Route("/posts/{BlogId}", "GET")]
    public class Posts : IReturn<List<Post>>
    {
        public long BlogId { get; set; }
    }
}