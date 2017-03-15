using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;

namespace FakeBlog.DAL
{
    public class FakeBlogRepository : IRepository
    {
        public FakeBlogContext Context;

        public FakeBlogRepository()
        {
        }

        public FakeBlogRepository(FakeBlogContext context)
        {
            Context = context;
        }

        public void AddPost(Post testPost, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void EditPostTitle(int postId, string title)
        {
            throw new NotImplementedException();
        }

        public void EditPostBody(int postId, string contents)
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