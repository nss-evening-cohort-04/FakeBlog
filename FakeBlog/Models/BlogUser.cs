﻿//NOT USING THIS - THIS IS FOR YOUR ERD..WE DID NOT DO THIS IN CLASS

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class BlogUser
    {
        [Key]
        public int BlogUserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}