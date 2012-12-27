using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace BlogBuiltBy.ServiceStack.Web.Dtos
{
    [Route("/blogs", "GET")]
    [Route("/blogs", "POST")]
    public class Blogs : IReturn<List<Blog>> 
    {
        private long[] _ids = new long[0];

        public Blogs(params long[] ids)
        {
            Ids = ids;
        }

        public long[] Ids
        {
            get { return _ids; }
            set { _ids = value; }
        }
    }
}