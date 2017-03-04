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
         public int DraftId { get; set; } 

         public string Name { get; set; }

         public string Text { get; set; }

         public int Time { get; set; }

         public List<Post> Posts { get; set; } // List # 1 a keyword //<> List # 2 is a File Ref // Lists = new var name 
 
         public Author Owner { get; set; } 

    }
}