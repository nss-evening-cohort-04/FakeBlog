using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;

namespace FakeBlog.DAL
{
    public class FakeBlogRepository : IRepository
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
        
        private List<PublishedPost> fake_post_table;

        public void AddPublishedPost(string title, ApplicationUser owner)
        {
            PublishedPost post = new PublishedPost { Title = title, Owner = owner};
            Context.Posts.Add(post);
            Context.SaveChanges();
        }

        public bool AttachAuthor(int authorId, int postId)
        {
            throw new NotImplementedException();
        }

        public PublishedPost GetPublishedPost(int postId)
        {
            PublishedPost found_Post = Context.Posts.FirstOrDefault(p => p.PublishedPostId == postId);
            return found_Post;
        }

        public List<PublishedPost> GetPublishedPostFromAuthor(string userId)
        {
            return Context.Posts.Where(p => p.Owner.Id == userId).ToList();
        }

        public bool IsDraft(int postId)
        {
            throw new NotImplementedException();
        }

        public bool PostDraft(int postId)
        {
            throw new NotImplementedException();
        }

        public bool RomovePublishedPost(int postId)
        {
            PublishedPost found_Post = GetPublishedPost(postId);
            if (found_Post != null)
            {
                Context.Posts.Remove(found_Post);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<PublishedPost> GetPublishedPostFromAuthor(int authorId)
        {
            throw new NotImplementedException();
        }
    }
}