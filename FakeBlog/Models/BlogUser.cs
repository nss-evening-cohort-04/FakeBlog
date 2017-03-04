using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class BlogUser
    {
        [Key]
        public int BlogUserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public ApplicationUser BaseUser { get; set; }

        public Profile UserProfile { get; set; }

        public List<Tweet> Tweets { get; set; }

        public List<Retweet> Retweets { get; set; }

        public List<Follower> Followers { get; set; }
    }
}