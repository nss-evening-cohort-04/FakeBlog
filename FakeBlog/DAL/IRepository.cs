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
        List<PublishedPost> GetPublishedPostFromAuthor(int authorId);

        PublishedPost GetPublishedPost(int postId);

        //Update
        bool AttachAuthor(int authorId, int postId);

        bool IsDraft(int postId);

        bool PostDraft(int postId);

        //Delete
        bool RomovePublishedPost(int postId);
    }
}