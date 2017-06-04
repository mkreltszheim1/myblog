using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.EntityFramework;
using MyBlog.Web.Models;

namespace MyBlog.Web.Repositories
{
    public class MyBlogRepository : IMyBlogRepository
    {
        public List<MyBlogSummaryModel> GetBlogSummaries()
        {
            using (var context = new MyBlogEntities())
            {
                return context.Blogs.OrderByDescending(b => b.DateCreated).Select(b => new MyBlogSummaryModel()
                {
                    Title = b.Title,
                    DateCreated = b.DateCreated,
                    Slug = b.Slug,
                    Summary = b.Summary
                }).ToList();
            }
        }

        public MyBlogArticleModel GetArticle(string slug)
        {
            using ( var context = new MyBlogEntities())
            {
                return context.Blogs.Where(b => b.Slug == slug).Select(b => new MyBlogArticleModel()
                {
                    Title = b.Title,
                    DateCreated = b.DateCreated,
                    BodyContent = b.BodyContent
                }).FirstOrDefault();
            }
        }
    }
}