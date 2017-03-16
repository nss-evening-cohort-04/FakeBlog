using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;

namespace FakeBlog.DAL
{
    public class FakeBlogRepository : IFakeBlogRepository
    {
        public FakeBlogContext Context { get; set; }

        public FakeBlogRepository()
        {
            Context = new FakeBlogContext();
        }

        public FakeBlogRepository(FakeBlogContext context)
        {
            Context = context;
        }

        public void CreateDraftPost(ApplicationUser owner, string postTitle, string postContent)
        {
            Post post = new Models.Post { User = owner, PostTitle = postTitle, PostContent = postContent, PostIsDraft = true };
            Context.Posts.Add(post);
            Context.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            throw new NotImplementedException();
        }

        public void EditDraftPost(int postId, string editedTitle, string editedContent)
        {
            throw new NotImplementedException();
        }

        //public List<Post> GetPublishedPosts(Author authorId)
        //{
        //    throw new NotImplementedException();
        //}

        public void PublishDraftPost(int postId)
        {
            throw new NotImplementedException();
        }
    }
}