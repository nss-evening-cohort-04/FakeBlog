using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeBlog.DAL;
using Moq;
using System.Data.Entity;
using FakeBlog.Models;
using System.Linq;
using System.Collections.Generic;

namespace FakeBlog.Tests
{
    [TestClass]
    public class FakeBlogRepoTests
    {
        public Mock<FakeBlogContext> fake_context { get; set; }
        public FakeBlogRepository repo { get; set; }
        public Mock<DbSet<Post>> mock_posts_set { get; set; }
        public IQueryable<Post> query_posts { get; set; }
        public List<Post> fake_post_table { get; set; }
        public ApplicationUser John { get; set; }
        public ApplicationUser Jane { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }

        [TestInitialize]
        public void Setup()
        {
            fake_post_table = new List<Post>();
            fake_context = new Mock<FakeBlogContext>();
            mock_posts_set = new Mock<DbSet<Post>>();
            repo = new FakeBlogRepository(fake_context.Object);

            John = new ApplicationUser { Id = "John-id-1", UserName = "John", Email = "john@gmail.com" };
            Jane = new ApplicationUser { Id = "Jane-id-1", UserName = "Jane", Email = "jane@gmail.com" };

            PostTitle = "My Coding Story";
            PostContent = "Blah blah blah blah blah blah blah blah blah blah blah blah blah.";
        }

        public void CreateFakeDatabase()
        {
            query_posts = fake_post_table.AsQueryable(); // Re-express this list as something that understands queries

            // Hey LINQ, use the Provider from our *cough* fake *cough* board table/list
            mock_posts_set.As<IQueryable<Post>>().Setup(b => b.Provider).Returns(query_posts.Provider);
            mock_posts_set.As<IQueryable<Post>>().Setup(b => b.Expression).Returns(query_posts.Expression);
            mock_posts_set.As<IQueryable<Post>>().Setup(b => b.ElementType).Returns(query_posts.ElementType);
            mock_posts_set.As<IQueryable<Post>>().Setup(b => b.GetEnumerator()).Returns(() => query_posts.GetEnumerator());

            mock_posts_set.Setup(a => a.Add(It.IsAny<Post>())).Callback((Post author) => fake_post_table.Add(author));

            mock_posts_set.Setup(a => a.Remove(It.IsAny<Post>())).Callback((Post author) => fake_post_table.Remove(author));

            fake_context.Setup(c => c.Posts).Returns(mock_posts_set.Object); // Context.Posts returns fake_author_table (a list)
        }

        [TestMethod]
        public void EnsureICanCreateInstanceofRepo()
        {
            FakeBlogRepository repo = new FakeBlogRepository();

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void EnsureIHaveNotNullContext()
        {
            FakeBlogRepository repo_local = new FakeBlogRepository();
            Assert.IsNotNull(repo_local.Context);
        }

        [TestMethod]
        public void EnsureICanInjectContextInstance()
        {
            Assert.IsNotNull(repo.Context);
        }

        [TestMethod]
        public void EnsureICanGetPosts()
        {
            CreateFakeDatabase();

            repo.CreateDraftPost(John, PostTitle, PostContent);
            repo.CreateDraftPost(John, PostTitle, PostContent);
            repo.CreateDraftPost(Jane, PostTitle, PostContent);

            List<Post> posts = repo.GetPosts(John);

            Assert.AreEqual(2, posts.Count());
        }

        [TestMethod]
        public void EnsureICanCreateDraftPost()
        {
            CreateFakeDatabase();

            repo.CreateDraftPost(John, PostTitle, PostContent);

            Assert.AreEqual(1, repo.Context.Posts.Count());
        }

        [TestMethod]
        public void EnsureICanPublishDraftPost()
        {
            CreateFakeDatabase();

            repo.CreateDraftPost(John, PostTitle, PostContent);

            bool _post0WasPublished = repo.PublishDraftPost(0);

            Assert.IsTrue(_post0WasPublished);

            // Also, ensure attempts to publish non-existant posts fail
            bool _post1WasPublished = repo.PublishDraftPost(1);

            Assert.IsFalse(_post1WasPublished);
        }

        [TestMethod]
        public void EnsureICanUnpublishPost()
        {
            CreateFakeDatabase();

            // First, create fake post
            repo.CreateDraftPost(John, PostTitle, PostContent);

            // Then, publish post
            bool _post0WasPublished = repo.PublishDraftPost(0);

            Assert.IsTrue(_post0WasPublished);

            // Finally, unpublish post
            bool _post0WasUnpublished = repo.UnpublishPost(0);

            Assert.IsTrue(_post0WasUnpublished);
        }

        [TestMethod]
        public void EnsureICanDeletePost()
        {
            CreateFakeDatabase();

            repo.CreateDraftPost(John, PostTitle, PostContent);

            bool _post0WasDeleted = repo.DeletePost(0);

            Assert.IsTrue(_post0WasDeleted);

            // Also, ensure attempts to delete non-existant posts fail
            bool _post1WasDeleted = repo.DeletePost(1);

            Assert.IsFalse(_post1WasDeleted);
        }

        [TestMethod]
        public void EnsureICanEditPostTitle()
        {
            CreateFakeDatabase();

            // First, create new draft post
            repo.CreateDraftPost(John, PostTitle, PostContent);

            Assert.AreEqual(1, repo.Context.Posts.Count());

            // Next, edit post title
            bool _post0TitleWasEdited = repo.EditPostTitle(0, "New Title");

            Assert.IsTrue(_post0TitleWasEdited);
        }

        [TestMethod]
        public void EnsureICanEditPostContent()
        {
            CreateFakeDatabase();

            // First, create new draft post
            repo.CreateDraftPost(John, PostTitle, PostContent);

            Assert.AreEqual(1, repo.Context.Posts.Count());

            // Next, edit post title
            bool _post0ContentWasEdited = repo.EditPostContent(0, "New content.");

            Assert.IsTrue(_post0ContentWasEdited);
        }
    }
}
