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
        public int PostId { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        public string BodyTexst { get; set; }
        public DateTime DateCreated {get; set;} //Required by default
        public DateTime PublishedTime { get; set; } //Required by default

        public bool IsDraft { get; set; } //!!you are using this instead of having a draft class!!

        public List<Comment> Comments { get; set; } // List # 1 a keyword //<> List # 2 is a File Ref // Lists = new var name 

    }
}