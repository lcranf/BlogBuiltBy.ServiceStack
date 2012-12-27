using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;

namespace BlogBuiltBy.ServiceStack.Web.Dtos
{
    [Route("/blog/{Id}", "GET")]
    [Route("/blog", "POST")]
    [Route("/blog", "PUT")]
    public class Blog
    {
        [AutoIncrement]
        public long Id { get; set; }

        public string Name { get; set; }
    }
}