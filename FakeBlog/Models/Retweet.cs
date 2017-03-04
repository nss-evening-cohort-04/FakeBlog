using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Retweet
    {
        [Key]
        public int RetweetId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}