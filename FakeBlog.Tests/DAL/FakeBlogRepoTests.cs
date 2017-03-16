using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeBlog.DAL;
using FakeBlog.Models;
using System.Linq;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;

namespace FakeBlog.Tests.DAL
{
    [TestClass]
    public class FakeBlogRepoTests
    {
        public Mock<FakeBlogContext> fake_context { get; set; }
        public FakeBlogRepository repo { get; set; }
        public Mock<DbSet<PublishedPost>> mock_posts_set { get; set; }
        public IQueryable<PublishedPost> query_posts { get; set; }
        public List<PublishedPost> fake_post_table { get; set; }
        public ApplicationUser gwen { get; set; }
        public ApplicationUser finn { get; set; }


        [TestInitialize]
        public void Setup()
        {
            fake_post_table = new List<PublishedPost>();
            fake_context = new Mock<FakeBlogContext>();
            mock_posts_set = new Mock<DbSet<PublishedPost>>();
            repo = new FakeBlogRepository(fake_context.Object);

            gwen = new ApplicationUser { Id = "gwen-id-1" };
            finn = new ApplicationUser { Id = "finn-id-1" };
        }

        public void CreateFakeDatabase()
        {
            query_posts = fake_post_table.AsQueryable();

            mock_posts_set.As<IQueryable<PublishedPost>>().Setup(p => p.Provider).Returns(query_posts.Provider);
            mock_posts_set.As<IQueryable<PublishedPost>>().Setup(p => p.Expression).Returns(query_posts.Expression);
            mock_posts_set.As<IQueryable<PublishedPost>>().Setup(p => p.ElementType).Returns(query_posts.ElementType);
            mock_posts_set.As<IQueryable<PublishedPost>>().Setup(p => p.GetEnumerator()).Returns(query_posts.GetEnumerator());

            mock_posts_set.Setup(b => b.Add(It.IsAny<PublishedPost>())).Callback((PublishedPost post) => fake_post_table.Add(post));
            mock_posts_set.Setup(b => b.Remove(It.IsAny<PublishedPost>())).Callback((PublishedPost post) => fake_post_table.Remove(post));
            fake_context.Setup(p => p.Posts).Returns(mock_posts_set.Object);

        }

        [TestMethod]
        public void EnsureICanCreateInstanceOfRepo()
        {
            FakeBlogRepository repo = new FakeBlogRepository();

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void EnsureIHaveNotNullContext()
        {
            FakeBlogRepository repo = new FakeBlogRepository();

            Assert.IsNotNull(repo.Context);
        }

        [TestMethod]
        public void EnsureICanInjectContextInstance()
        {
            FakeBlogContext context = new FakeBlogContext();
            FakeBlogRepository repo = new FakeBlogRepository(context);

            Assert.IsNotNull(repo.Context);
        }

        [TestMethod]
        public void EnsureICanAddPublishedPost()
        {
            CreateFakeDatabase();

            ApplicationUser a_user = new ApplicationUser();
            {
                Id = 1,
                UserName = "Sammy",
                Email = "sammy@gmail.com"
            };
        }
    }
}
