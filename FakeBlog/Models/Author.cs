﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        public string AuthorName { get; set; }

        public string AuthorPasswordHash { get; set; }

        public DateTime AuthorJoinDate { get; set; }

        public ApplicationUser User { get; set; }

        public List<Post> Posts { get; set; } // 1 to many relationship
    }
}