using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeBlog.DAL;

namespace FakeBlog.Tests
{
    [TestClass]
    public class FakeBlogRepoTests
    {
        [TestMethod]
        public void EnsureICanCreateInstanceofRepo()
        {
            FakeBlogRepository repo = new FakeBlogRepository();

            Assert.IsNotNull(repo);
        }
    }
}
