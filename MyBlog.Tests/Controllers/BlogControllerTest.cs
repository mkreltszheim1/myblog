using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlog.Web;
using MyBlog.Web.Controllers;

namespace MyBlog.Tests.Controllers
{
    [TestClass]
    public class BlogControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void BlogArticleNotFoundTest()
        {
            var controller = new BlogController();

            // non-existent slug
            var slug = "aaaaaaaaaaaaaaaaaa";

            controller.Article(slug);
        }

        [TestMethod]
        public void BlogArticleFoundTest()
        {
            var controller = new BlogController();

            // non-existent slug
            var slug = "all-the-tourist-stuff-you-should-probably-do-in-stockholm";

            var result = controller.Article(slug);

            Assert.IsInstanceOfType(result, (typeof(ActionResult)));
        }

        [TestMethod]
        public void BlogListNullPageTest()
        {
            var controller = new BlogController();

            var result = controller.Index(null);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BlogListInvalidPageTest()
        {
            var controller = new BlogController();

            var result = controller.Index(-100);

            Assert.IsNotNull(result);

            result = controller.Index(0);

            Assert.IsNotNull(result);
        }
    }
}
