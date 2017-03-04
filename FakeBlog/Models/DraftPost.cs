using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class DraftPost
    {
        public Author AuthorID { get; set; }

        [Key]
        public int DraftPostID { get; set; }

        public string DraftPostTitle { get; set; }

        public string DraftPostContent { get; set; }

        public PublishedPost PublishedPostID { get; set; }
    }
}