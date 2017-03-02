using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Follower
    {
        [Key]
        public int FollowerId { get; set; }

        public string Name { get; set; }
    }
}