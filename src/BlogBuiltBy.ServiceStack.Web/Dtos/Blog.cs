using ServiceStack.ServiceHost;

namespace BlogBuiltBy.ServiceStack.Web.Dtos
{
    [Route("/blog", "POST")]
    [Route("/blog", "PUT")]
    [Route("/blog", "DELETE")]
    public class Blog
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}