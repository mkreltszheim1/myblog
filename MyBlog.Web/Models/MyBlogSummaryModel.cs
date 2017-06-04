using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Web.Models
{
    public class MyBlogSummaryModel
    {
        public string Title { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Summary { get; set; }
        public string Slug { get; set; }
    }
}