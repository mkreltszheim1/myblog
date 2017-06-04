using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using MyBlog.Web.Models;

namespace MyBlog.Web.Repositories
{
    public interface IMyBlogRepository
    {
        List<MyBlogSummaryModel> GetBlogSummaries();

        MyBlogArticleModel GetArticle(string slug);
    }
}