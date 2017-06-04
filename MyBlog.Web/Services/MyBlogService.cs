using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Web.Models;
using MyBlog.Web.Repositories;

namespace MyBlog.Web.Services
{
    public class MyBlogService : IMyBlogService
    {
        public IMyBlogRepository _repository;

        public MyBlogService(IMyBlogRepository repository)
        {
            _repository = repository;
        }

        public List<MyBlogSummaryModel> GetBlogSummaries()
        {
            return _repository.GetBlogSummaries();
        }

        public MyBlogArticleModel GetArticle(string slug)
        {
            return _repository.GetArticle(slug);
        }
    }
}