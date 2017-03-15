using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeBlog.DAL
{
    public interface IRepository
    {
        //Create
        void AddPublishedPost(string title, ApplicationUser owner);

        //Read
        List<PublishedPost> GetPublishedPostFromUser(int AuthorId);

        PublishedPost GetPublishedPost(int PublishedPostId);

        //Update
        bool AttachUser(int AuthorId, int PublishedPostId);

        //Delete
        bool RomovePublishedPost(int PublishedPostId);
    }
}