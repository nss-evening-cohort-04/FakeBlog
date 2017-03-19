using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeBlog.DAL;
using FakeBlog.Models;
using System.Data.Entity;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FakeBlog.Tests.DAL
{
    [TestClass]
    public class FakeBlogRepoTests
    {
        public Mock<FakeBlogContext> fake_context { get; set; }
        public FakeBlogRepository repo { get; set; }
        public Mock<DbSet<Tweet>> mock_tweets_set { get; set; }
        public IQueryable<Tweet> query_Tweets { get; set; }
        public List<Tweet> fake_Tweet_table { get; set; }
        public ApplicationUser sally { get; set; }
        public ApplicationUser sammy { get; set; }


        [TestInitialize]
        public void Setup()
        {
            fake_Tweet_table = new List<Tweet>();
            fake_context = new Mock<FakeBlogContext>();
            mock_tweets_set = new Mock<DbSet<Tweet>>();
            repo = new FakeBlogRepository(fake_context.Object);
            sally = new ApplicationUser { Id = "sally-id-1" };
            sammy = new ApplicationUser { Id = "sammy-id-1" };
        }

        public void CreateFakeDatabase()
        {
            query_Tweets = fake_Tweet_table.AsQueryable(); // Re-express this list as something that understands queries

            // Hey LINQ, use the Provider from our *cough* fake *cough* Tweet table/list
            mock_tweets_set.As<IQueryable<Tweet>>().Setup(b => b.Provider).Returns(query_Tweets.Provider);
            mock_tweets_set.As<IQueryable<Tweet>>().Setup(b => b.Expression).Returns(query_Tweets.Expression);
            mock_tweets_set.As<IQueryable<Tweet>>().Setup(b => b.ElementType).Returns(query_Tweets.ElementType);
            mock_tweets_set.As<IQueryable<Tweet>>().Setup(b => b.GetEnumerator()).Returns(() => query_Tweets.GetEnumerator());

            mock_tweets_set.Setup(b => b.Add(It.IsAny<Tweet>())).Callback((Tweet Tweet) => fake_Tweet_table.Add(Tweet));
            mock_tweets_set.Setup(b => b.Remove(It.IsAny<Tweet>())).Callback((Tweet Tweet) => fake_Tweet_table.Remove(Tweet));
            fake_context.Setup(c => c.Tweets).Returns(mock_tweets_set.Object); // Context.Tweets returns fake_Tweet_table (a list)
            fake_context.Setup(c => c.SaveChanges()).Returns(0).Verifiable();
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
        public void EnsureICanAddTweet()
        {
            // Arrange
            CreateFakeDatabase();

            ApplicationUser a_user = new ApplicationUser
            {
                Id = "my-user-id",
                UserName = "Sammy",
                Email = "sammy@gmail.com"
            };

            // Act
            repo.AddTweet("My Tweet", a_user);

            // Assert
            Assert.AreEqual(1, repo.Context.Tweets.Count());
        }

        [TestMethod]
        public void EnsureICanFindATweet()
        {
            // Arrange
            fake_Tweet_table.Add(new Tweet { TweetId = 1, Title = "My Tweet" });
            CreateFakeDatabase();

            // Act
            string expected_Tweet_title = "My Tweet";
            Tweet actual_Tweet = repo.GetTweet(1);
            string actual_Tweet_title = repo.GetTweet(1).Title;

            // Assert
            Assert.IsNotNull(actual_Tweet);
            Assert.AreEqual(expected_Tweet_title, actual_Tweet_title);
        }

        [TestMethod]
        public void EnsureICanRemoveTweet()
        {
            // Arrange
            fake_Tweet_table.Add(new Tweet { TweetId = 1, Title = "My Tweet", Owner = sally });
            fake_Tweet_table.Add(new Tweet { TweetId = 2, Title = "My Tweet", Owner = sally });
            fake_Tweet_table.Add(new Tweet { TweetId = 3, Title = "My Tweet", Owner = sammy });
            CreateFakeDatabase();

            // Act
            int expected_Tweet_count = 2;
            repo.RemoveTweet(3);
            int actual_Tweet_count = repo.Context.Tweets.Count();

            // Assert
            Assert.AreEqual(expected_Tweet_count, actual_Tweet_count);
        }

        [TestMethod]
        public void EnsureICanModifyTweet()
        {
            // Arrange
            fake_Tweet_table.Add(new Tweet { TweetId = 1, Title = "My Tweet", Owner = sally });
            fake_Tweet_table.Add(new Tweet { TweetId = 2, Title = "My another Tweet", Owner = sally });
            CreateFakeDatabase();

            // Act
            repo.ReplaceTweetTitle(2, "new tweet title");
            string expected_tweet_title = "new tweet title";
            string actual_tweet_title = repo.GetTweet(2).Title;

            // Assert
            Assert.AreEqual(expected_tweet_title, actual_tweet_title);
            fake_context.Verify((c => c.SaveChanges()), Times.Once());
        }
    }
}
