using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;

namespace FakeBlog.DAL
{
    public class FakeBlogRepository : IRepository
    {
        public void AddPost(Post newPost)
        {
            throw new NotImplementedException();
        }

        public void EditDraft(int postId, string contents)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int postId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPostsFromAuthor(string authorId)
        {
            throw new NotImplementedException();
        }

        public void PublishPost(int postId)
        {
            throw new NotImplementedException();
        }

        public void RemovePost(int postId)
        {
            throw new NotImplementedException();
        }
    }
}