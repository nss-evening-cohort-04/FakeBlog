using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Tweet
    {
        [Key]
        public int TweetId { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        public string DateCreated { get; set; } // Required by default

        public string Content { get; set; }

        public ApplicationUser Owner { get; set; }

        public List<Tweet> Retweets { get; set; }
    }
}