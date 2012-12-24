using System;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ServiceStack.ServiceHost;

namespace BlogBuiltBy.ServiceStack.Web.Dtos
{
    [Route("/post/{Id}", "GET")]
    [Route("/post/{Id}", "DELETE")]
    [Route("/post/{BlogId}/{Title}/{Message}/{Author}", "POST")]
    [Route("/post/{Id}/{Title}/{Message}", "PUT")]
    public class Post
    {
        [AutoIncrement]
        public long Id { get; set; }

        [ForeignKey(typeof(Blog), OnDelete = "CASCADE")]
        public long BlogId { get; set; }
        
        public string Title { get; set; }

        public string Message { get; set; }

        public string Author { get; set; }
        
        public DateTime CreatedOn { get; set; }
    }
}