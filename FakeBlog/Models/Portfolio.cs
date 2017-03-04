using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Portfolio
    {
        [Key]
        public string PortfolioId { get; set; }

        public string Drafts { get; set; }

        public string DraftNotes { get; set; }

        public List<PortfolioToPublishedPost> Posts { get; set; }
    }
}