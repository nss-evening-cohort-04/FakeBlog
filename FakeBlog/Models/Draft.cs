using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Draft
    {
        [Key]
        public int DraftId { get; set; } //Primary key

        public string Title { get; set; } //Draft Name

        public string Contents { get; set; } //Draft Contents

        public string Genre { get; set; } //Draft Genre

        public string MainTopic { get; set; } //Draft MainTopic

        public DateTime DateCreated { get; set; }

        public User Author { get; set; } // 1 to 1 relationship

        public List<PublishedPost> PublishedPosts { get; set; } // 1 to many (posts) relationship
    }
}