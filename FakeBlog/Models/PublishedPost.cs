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

        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        public string Comments { get; set; }

        public DateTime DateCreated { get; set; } //Required by default

        public DateTime PublishedAt { get; set; }

        public bool Edited { get; set; }

        public bool IsDraft { get; set; }
    }
}