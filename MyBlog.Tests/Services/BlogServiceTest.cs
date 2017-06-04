using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlog.Web.Models;
using MyBlog.Web.Repositories;
using MyBlog.Web.Services;

namespace MyBlog.Tests.Services
{
    [TestClass]
    public class BlogServiceTest
    {
        [TestMethod]
        public void BlogArticleNotFoundTest()
        {
            var service = new MyBlogService(new MyBlogRepository());

            // non-existent slug
            var slug = "aaaaaaaaaaaa";

            var blog = service.GetArticle(slug);
            Assert.IsNull(blog);
        }

        [TestMethod]
        public void BlogArticleNullSlugTest()
        {
            var service = new MyBlogService(new MyBlogRepository());
            var blog = service.GetArticle(null);
            Assert.IsNull(blog);
        }

        [TestMethod]
        public void BlogArticleFoundTest()
        {
            var service = new MyBlogService(new MyBlogRepository());
            var slug = "all-the-tourist-stuff-you-should-probably-do-in-stockholm";
            var blog = service.GetArticle(slug);
            Assert.IsNotNull(blog);
        }

        [TestMethod]
        public void BlogArticleCorrectTypeTest()
        {
            var service = new MyBlogService(new MyBlogRepository());
            var slug = "all-the-tourist-stuff-you-should-probably-do-in-stockholm";
            var blog = service.GetArticle(slug);
            Assert.IsInstanceOfType(blog, (typeof(MyBlogArticleModel)));
        }

        [TestMethod]
        public void BlogListFoundTest()
        {
            var service = new MyBlogService(new MyBlogRepository());
            var blogs = service.GetBlogSummaries();
            Assert.IsTrue(blogs.Count > 0);
        }

        [TestMethod]
        public void BlogListCorrectTypeTest()
        {
            var service = new MyBlogService(new MyBlogRepository());
            var blogs = service.GetBlogSummaries();
            Assert.IsInstanceOfType(blogs, (typeof(List<MyBlogSummaryModel>)));
        }

        [TestMethod]
        public void BlogListOrderTest()
        {
            var service = new MyBlogService(new MyBlogRepository());
            var blogs = service.GetBlogSummaries();
            var blogsOrdered = blogs.OrderByDescending(b => b.DateCreated).ToList();
            CollectionAssert.AreEqual(blogs, blogsOrdered);
        }
    }
}
