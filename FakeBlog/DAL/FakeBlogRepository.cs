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
            Post post = new Post { User = owner, PostTitle = postTitle, PostContent = postContent, PostIsDraft = true };
            Context.Posts.Add(post);
            Context.SaveChanges();
        }

        public bool DeletePost(int postId)
        {
            Post postToDelete = Context.Posts.FirstOrDefault(post => post.PostID == postId);
            if (postToDelete != null)
            {
                Context.Posts.Remove(postToDelete);
                Context.SaveChanges();
                // Return true if post exists
                return true;
            }
            return false;
        }

        public void EditDraftPost(int postId, string editedTitle, string editedContent)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPosts(ApplicationUser owner)
        {
            throw new NotImplementedException();
        }

        public bool PublishDraftPost(int postId)
        {
            Post postToPublish = Context.Posts.FirstOrDefault(post => post.PostID == postId);
            if (postToPublish != null)
            {
                postToPublish.PostIsDraft = false;
                Context.SaveChanges();
                // Return true if post exists
                return true;
            }
            return false;
        }
    }
}