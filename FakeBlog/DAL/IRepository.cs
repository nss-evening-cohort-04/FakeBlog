using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBlog.DAL
{
    interface IRepository
    {
        // List of methods to help deliver features
        // Create
        void AddTweet(string title, ApplicationUser owner);

        // Read
        Tweet GetTweet(int tweetId);

        // Update
        bool ReplaceTweetTitle(int tweetId, string newTitle); // true: successful, false: not successful

        // Delete
        bool RemoveTweet(int tweetId);
    }
}
