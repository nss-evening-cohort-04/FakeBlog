using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }


        [MinLength(10)] //you have the ability to stack these properties
        [MaxLength(60)]
        public string Email { get; set; }


        [MaxLength(60)]
        public string UserName { get; set; }


        [MaxLength(60)]
        public string FullName { get; set; }


        public ApplicationUser BaseUser { get; set; } //this is creating the relationship btw tables (1 to 1)- this is how you tie together classes 
                                                      //ApplicationUser is from the IdentityModels file 


        //****List<Board> and Icollection<Board> are navigation properties 
        public List<Draft> Drafts { get; set; } // 1 to many (boards) relationship 


        //public ICollection<Board> Boards { get; set; } // this is the same as the above- they are both  nav properties 
    }
}