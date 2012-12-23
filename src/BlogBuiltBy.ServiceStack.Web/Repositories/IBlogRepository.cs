using System.Collections.Generic;
using BlogBuiltBy.ServiceStack.Web.Dtos;

namespace BlogBuiltBy.ServiceStack.Web.Repositories
{
    public interface IBlogRepository
    {
        IList<Blog> FindByIds(long[] ids);
        IList<Blog> GetAll();
        Blog Update(Blog blog);
        bool Delete(long[] ids);
        Blog Create(Blog blog);
    }
}