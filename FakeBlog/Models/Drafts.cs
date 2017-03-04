using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FakeBlog.Models
{
    public class Drafts
    {
        [Key]
        public int idDrafts { get; set; }

        public string Title { get; set; }

        public ICollection<PublishedPosts> Published { get; set; }
    }
}