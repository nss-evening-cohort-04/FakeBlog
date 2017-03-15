using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class BlogPost
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public DateTime DateCreated { get; set; }  //required by default

        public DateTime PublishedTime { get; set; }

        public string Body { get; set; }

        public bool IsDraft { get; set; }

        public string URL { get; set; }
    }
}