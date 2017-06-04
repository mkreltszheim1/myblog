using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Web.Models;

namespace MyBlog.Web.Services
{
    public interface IMyBlogService
    {
        List<MyBlogSummaryModel> GetBlogSummaries();

        MyBlogArticleModel GetArticle(string slug);
    }
}