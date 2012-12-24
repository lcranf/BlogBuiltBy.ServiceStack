using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;

namespace BlogBuiltBy.ServiceStack.Web.Dtos
{
    [Route("/blog", "POST")]
    [Route("/blog", "PUT")]
    [Route("/blog/{Id}", "DELETE")]
    public class Blog
    {
        [AutoIncrement]
        public long Id { get; set; }

        public string Name { get; set; }
    }
}