using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeBlog.DAL;
using Moq;
using FakeBlog.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace FakeBlog.Tests
{
    [TestClass]
    public class FakeBlogRepoTests
    {
        public Mock<FakeBlogContext> fakeContext { get; set; }
        public FakeBlogRepository repo { get; set; }
        public Mock<DbSet<Post>> mockPostSet { get; set; }
        public IQueryable<Post> queryPosts { get; set; }
        public List<Post> fakePostTable { get; set; }

        [TestInitialize]
        public void Setup()
        {
            fakePostTable = new List<Post>();
            fakeContext = new Mock<FakeBlogContext>();
            mockPostSet = new Mock<DbSet<Post>>();
            repo = new FakeBlogRepository(fakeContext.Object);
        }

        public void InitializeTempDatabase()
        {
            queryPosts = fakePostTable.AsQueryable();
            mockPostSet.As<IQueryable<Post>>().Setup(b => b.Provider).Returns(queryPosts.Provider);
            mockPostSet.As<IQueryable<Post>>().Setup(b => b.Expression).Returns(queryPosts.Expression);
            mockPostSet.As<IQueryable<Post>>().Setup(b => b.ElementType).Returns(queryPosts.ElementType);
            mockPostSet.As<IQueryable<Post>>().Setup(b => b.GetEnumerator()).Returns(() => queryPosts.GetEnumerator());

            mockPostSet.Setup(b => b.Add(It.IsAny<Post>())).Callback((Post post) => fakePostTable.Add(post));
            fakeContext.Setup(c => c.Posts).Returns(mockPostSet.Object);
        }

        [TestMethod]
        public void EnsureICanCreateInstanceofRepo()
        {
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
        public void EnsureICanCreatePost()
        {

        }

    }
}
