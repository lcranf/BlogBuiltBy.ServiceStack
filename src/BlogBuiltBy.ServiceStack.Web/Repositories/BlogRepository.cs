﻿using System.Collections.Generic;
using System.Linq;
using BlogBuiltBy.ServiceStack.Web.Dtos;
using ServiceStack.OrmLite;

namespace BlogBuiltBy.ServiceStack.Web.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public IList<Blog> FindByIds(long[] ids)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                return db.GetByIds<Blog>(ids);
            }
        }

        public IList<Blog> GetAll()
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                return db.Each<Blog>().ToList();
            }
        }

        public Blog Create(Blog blog)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.Insert(blog);
                blog.Id = db.GetLastInsertId();
            }

            return blog;
        }
        public Blog Update(Blog blog)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.Update(blog, b => b.Id == blog.Id);
            }

            return blog;
        }

        public bool Delete(long[] ids)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.DeleteByIds<Blog>(ids);
            }

            return true;
        }
    }
}