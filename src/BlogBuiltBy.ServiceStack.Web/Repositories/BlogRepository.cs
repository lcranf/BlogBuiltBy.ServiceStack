using System.Collections.Generic;
using System.Linq;
using BlogBuiltBy.ServiceStack.Web.Dtos;

namespace BlogBuiltBy.ServiceStack.Web.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly List<Blog> _blogs = new List<Blog>(
            new[]
                {
                    new Blog { Id = 1, Name = "Blog 1" },
                    new Blog { Id = 2, Name = "Blog 2" }
                }
            );

        public IList<Blog> FindByIds(long[] ids)
        {
            return _blogs.Where(x => ids.Contains(x.Id)).ToList();
        }

        public IList<Blog> GetAll()
        {
            return _blogs.ToList();
        }

        public Blog AddOrUpdate(Blog blog)
        {
            var existingBlog = _blogs.SingleOrDefault(x => x.Id.Equals(blog.Id));
            
            if (existingBlog == null)
            {
                var newId = _blogs.Any() ? _blogs.Max(x => x.Id) + 1 : 1L;
                blog.Id = newId;
                _blogs.Add(blog);
                return blog;
            }

            existingBlog.Name = blog.Name;
            return existingBlog;
        }

        public bool Delete(long[] ids)
        {
            return _blogs.RemoveAll(x => ids.Contains(x.Id)) > 0;
        }
    }
}