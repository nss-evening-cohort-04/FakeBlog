using System;
using System.ComponentModel.DataAnnotations;

namespace FakeBlog.Models
{
    public class PublishedPosts
    {
        [Key]
        public int idPublishedPosts { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        public string Body { get; set;   }

        public DateTime create_time { get; set; } // required by default
        public DateTime update_time { get; set; }

        public bool IsDraft { get; set; }


    }
}