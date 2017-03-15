﻿using System;
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

        [TestInitialize]
        public void Setup()
        {
            fake_post_table = new List<Post>();
            fake_context = new Mock<FakeBlogContext>();
            mock_posts_set = new Mock<DbSet<Post>>();
            repo = new FakeBlogRepository(fake_context.Object);

            John = new ApplicationUser { Id = "John-id-1", UserName = "John", Email = "john@gmail.com" };
            Jane = new ApplicationUser { Id = "Jane-id-1", UserName = "Jane", Email = "jane@gmail.com" };
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
        public void EnsureICanCreateDraftPost()
        {
            CreateFakeDatabase();

            string _postTitle = "My Coding Story";
            string _postContent = "Blah blah blah blah blah blah blah blah blah blah blah blah blah.";

            repo.CreateDraftPost(John, _postTitle, _postContent);

            Assert.AreEqual(1, repo.Context.Posts.Count());
        }
    }
}
