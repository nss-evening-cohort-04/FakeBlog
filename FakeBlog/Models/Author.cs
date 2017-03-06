using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public List<Blog> Blogs { get;  set}
    }
}