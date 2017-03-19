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


        public void AddTweet(string title, ApplicationUser owner)
        {
            Tweet tweet = new Tweet { Title = title, Owner = owner };
            Context.Tweets.Add(tweet);
            Context.SaveChanges();
        }
        
        public bool ReplaceTweetTitle(int tweetId, string newTitle)
        {
            Tweet found_tweet = GetTweet(tweetId);
            if (found_tweet != null)
            {
                found_tweet.Title = newTitle;
                Context.SaveChanges();
                return true;
            }
            return false;
        }
        
        public Tweet GetTweet(int tweetId)
        {
            Tweet found_tweet = Context.Tweets.FirstOrDefault(b => b.TweetId == tweetId); // returns null if nothing is found
            return found_tweet;
        }

        public bool RemoveTweet(int tweetId)
        {
            Tweet found_tweet = GetTweet(tweetId);
            if (found_tweet != null)
            {
                Context.Tweets.Remove(found_tweet);
                Context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}