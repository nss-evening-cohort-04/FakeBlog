using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class PublishedPost
    {
        public Author AuthorID { get; set; }

        [Key]
        public int PublishedPostID { get; set; }

        [Required]
        [MinLength(3)]
        public string PublishedPostTitle { get; set; }

        public string PublishedPostContent { get; set; }

        public PublishedPost DraftPostID { get; set; }
    }
}