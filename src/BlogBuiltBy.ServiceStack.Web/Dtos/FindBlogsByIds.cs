using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace BlogBuiltBy.ServiceStack.Web.Dtos
{
    [Route("/blogs", "GET")]
    [Route("/blogs", "POST")]
    [Route("/blogs", "DELETE")]
    public class FindBlogsByIds : IReturn<List<Blog>> 
    {
        private long[] _ids = new long[0];

        public long[] Ids
        {
            get { return _ids; }
            set { _ids = value; }
        }

        public FindBlogsByIds(params long[] ids)
        {
            Ids = ids;
        }
    }
}