using ServiceStack.ServiceHost;

namespace BlogBuiltBy.ServiceStack.Web.Dtos
{
    [Route("/blog/delete/{Id}")]
    public class DeleteBlog
    {
        public int Id { get; set; }
    }
}