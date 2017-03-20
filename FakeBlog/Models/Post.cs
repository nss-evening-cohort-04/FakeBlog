using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        [Required]
        [MinLength(3)]
        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public bool PostIsDraft { get; set; }

        public ApplicationUser User { get; set; }
    }
}