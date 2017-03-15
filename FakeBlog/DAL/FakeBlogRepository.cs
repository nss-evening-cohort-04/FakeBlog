using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;

namespace FakeBlog.DAL
{
    public class FakeBlogRepository : IRepository
    {
        public void AddPublishedPost(string title, ApplicationUser owner)
        {
            throw new NotImplementedException();
        }

        public bool AttachUser(int AuthorId, int PublishedPostId)
        {
            throw new NotImplementedException();
        }

        public PublishedPost GetPublishedPost(int PublishedPostId)
        {
            throw new NotImplementedException();
        }

        public List<PublishedPost> GetPublishedPostFromUser(int AuthorId)
        {
            throw new NotImplementedException();
        }

        public bool RomovePublishedPost(int PublishedPostId)
        {
            throw new NotImplementedException();
        }
    }
}