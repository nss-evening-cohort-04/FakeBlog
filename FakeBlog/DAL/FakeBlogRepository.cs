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

        public void AddPost(Post newPost, ApplicationUser userHere) 
        {
            Context.Posts.Add(newPost);
            Context.SaveChanges();
            //--->this not working<---//
        }

        public void EditPostBody(int postId, string newContents)
        {
            Post postToEdit = GetPost(postId);
            newContents = postToEdit.Contents;
            Context.Posts.Attach(postToEdit);
            Context.SaveChanges();
            //--->this not working<---//
        }

        public void EditPostTitle(int postId, string newTitle)
        {
            Post postToEdit = GetPost(postId);
            newTitle = postToEdit.Title;
            Context.Posts.Attach(postToEdit);
            Context.SaveChanges();
            //--->this not working<---//
        }

        public Post GetPost(int postId)
        {
            Post postIWant = Context.Posts.FirstOrDefault(p => p.PostId == postId);
            return postIWant;
            //--->this not working<---//
        }

        public List<Post> GetPostsFromAuthor(string authorId)
        {
            return Context.Posts.Where(p => p.AuthorId.AuthorId == authorId).ToList();
            //--->this not working<---//
        }

        public void PublishPost(int postId)
        {
            Post postToEdit = GetPost(postId);
            if (postToEdit.IsDraft == true)
            {
                //set IsDraft to false ... not sure how to do that
            }
            Context.Posts.Attach(postToEdit);
            Context.SaveChanges();
            //--->this not working<---//
        }

        public void RemovePost(int postId)
        {
            Post postToRemove = GetPost(postId);
            if (postToRemove != null)
            {
                Context.Posts.Remove(postToRemove);
                Context.SaveChanges();
            }
            //--->this not working<---//
        }
    }
}