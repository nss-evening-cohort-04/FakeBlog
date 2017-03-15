using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;

namespace FakeBlog.DAL
{
    public class FakeBlogRepository : IFakeBlogRepository
    {
        public FakeBlogRepository()
        {

        }

        public void AddAuthor(string authorName, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void CreateDraftPost(Author authorId, string postTitle, string postContent)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int postId)
        {
            throw new NotImplementedException();
        }

        public void EditDraftPost(int postId, string editedTitle, string editedContent)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPublishedPosts(Author authorId)
        {
            throw new NotImplementedException();
        }

        public void PublishDraftPost(int postId)
        {
            throw new NotImplementedException();
        }
    }
}