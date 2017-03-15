using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBlog.DAL
{
    public interface IRepository
    {
        // List of methods to help deliver features
        // Create
        void AddPost(Post newPost);

        // Read
        Post GetPost(int postId);
        List<Post> GetPostsFromAuthor(string authorId);

        // Update
        void PublishPost(int postId);
        void EditDraft(int postId, string contents);

        // Delete
        void RemovePost(int postId);
    }
}
