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

        public string Title { get; set; }

        public string Content { get; set; }

        public List<Retweet> Retweets { get; set; }
    }
}