using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class PublishedPost
    {
        [Key]
        public int PublishedPostId { get; set; }

        public string Comments { get; set; }

        public List<PortfolioToPublishedPost> Posts { get; set; }
    }
}