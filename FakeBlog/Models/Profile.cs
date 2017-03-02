using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthdayHash { get; set; }

        public string Profession { get; set; }

        public string ImgURL { get; set; }
    }
}