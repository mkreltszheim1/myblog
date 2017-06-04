using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlog.EntityFramework;
using MyBlog.Web.Helper;
using MyBlog.Web.Repositories;
using MyBlog.Web.Services;
using PagedList;

namespace MyBlog.Web.Controllers
{
    public class BlogController : Controller
    {
        private IMyBlogService _myBlogService;

        public BlogController()
        {
            _myBlogService = new MyBlogService(new MyBlogRepository());
        }

        // GET: blog
        public ActionResult Index(int? page)
        {
            var pageSize = MyBlogConstants.PageSize;

            // if nonsensical page passed, set to null
            if (page < 1) page = null;

            // if page is null set to first page
            var pageNumber = (page ?? 1);
            
            var blogs = _myBlogService.GetBlogSummaries();

            return View(blogs.ToPagedList(pageNumber, pageSize));
        }

        // GET: blog/slug-value
        public ActionResult Article(string slug)
        {
            // Used to remember the pagination value for the back button
            ViewBag.Page = (Request != null && Request.UrlReferrer != null)
                ? HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["page"]
                : null;

            var blog = _myBlogService.GetArticle(slug);

            // Return 404 if blog could not be found
            if (blog == null)
                throw  new HttpException(404, "Not found");

            return View(blog);
        }
    }
}
