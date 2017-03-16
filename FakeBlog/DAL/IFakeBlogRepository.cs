using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBlog.DAL
{
    public interface IFakeBlogRepository
    {
        // Published posts will be viewable by everyone
        List<Post> GetPosts(ApplicationUser owner);

        // Authors will be able to make drafts for blog posts
        void CreateDraftPost(ApplicationUser owner, string postTitle, string postContent);

        // Authors will be able to manually publish a draft.
        bool PublishDraftPost(int postId);

        // Authors will be able to delete published posts and drafts
        bool DeletePost(int postId);

        // Authors will be able to edit a drafts
        void EditDraftPost(int postId, string editedTitle, string editedContent);
    }
}
