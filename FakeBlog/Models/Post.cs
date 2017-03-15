using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; } //Primary key

        [DefaultValue(true)]
        public bool IsDraft { get; set; } //Post is a Draft or Published

        [Required]
        public string Title { get; set; } //Post Name
        
        [Required]
        public string Contents { get; set; } //Post Contents

        public DateTime DateCreated { get; set; }

        public ApplicationUser Author { get; set; } // 1 to 1 relationship
    }
}