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
        public int PublishedPostId { get; set; } //Primary key

        public Draft OriginalDraft { get; set; } // 1 to 1 relationship

        public DateTime DatePosted { get; set; }

    }
}