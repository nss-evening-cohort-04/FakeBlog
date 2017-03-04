using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Author
    {
        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; }
        
        public List<string> Posts { get; set; }

    }
}