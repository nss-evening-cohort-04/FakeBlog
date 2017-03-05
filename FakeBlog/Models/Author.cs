using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Author
    {
        [Key] 
        public int AuthorId { get; set; } 

        [MaxLength(20)]
        public string Username { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        public ApplicationUser BaseUser { get; set; } 

        public List<PublishedPost> Posts { get; set; } 
    }
}