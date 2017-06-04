using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlog.Web;
using MyBlog.Web.Controllers;

namespace MyBlog.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexReturnRedirectResult()
        {
            var controller = new HomeController();

            var result = controller.Index() as RedirectResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexRedirectsToBlog()
        {
            var controller = new HomeController();

            var result = controller.Index() as RedirectResult;
            if (result == null)
                Assert.Fail();

            Assert.AreEqual(result.Url, "/blog");
        }
    }
}
