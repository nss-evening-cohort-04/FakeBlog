using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Post
    {
        public Author AuthorID { get; set; }

        [Key]
        public int PostID { get; set; }

        [Required]
        [MinLength(3)]
        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public bool isDraft { get; set; }
    }
}