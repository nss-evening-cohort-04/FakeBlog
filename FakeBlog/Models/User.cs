using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class User
    {
        [Key]
        public int BlogUserId { get; set; } //Primary key

        [MinLength(10)]
        [MaxLength(60)]
        public string Email { get; set; } //user email

        [MaxLength(60)]
        public string Username { get; set; } //username

        [MaxLength(60)]
        public string FirstName { get; set; } //user First Name

        [MaxLength(60)]
        public string LastName { get; set; } //user First Name

        public ApplicationUser BaseUser { get; set; } // 1 to 1 relationship

        public List<Draft> Drafts { get; set; } // 1 to many (drafts) relationship
    }
}