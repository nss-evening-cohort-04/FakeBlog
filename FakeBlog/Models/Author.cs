using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FakeBlog.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<Post> Posts { get; set; }
    }
}