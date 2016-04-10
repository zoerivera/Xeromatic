using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweet = Xeromatic.Models.Tweet;
using Xeromatic.Services;

namespace Xeromatic.Services
{
    public class TwitterApiService : ITwitterService
    {
        // Get keys from: https://apps.twitter.com
        // Wiki for tweetinvi: https://github.com/linvi/tweetinvi/wiki

        readonly TwitterCredentials _creds;

        public TwitterApiService()
        {
            _creds = new TwitterCredentials
            {
                ConsumerKey = "yW5X6PiZQ2HguljiMUpuX5iMz",
                ConsumerSecret = "RQFZi6tV48bfMtKi09LikDjJ7EweBQdlLZlYBMGDhOhpz8LVzN",
                AccessToken = "718574901339095040-ofUmnikwV2uYOskLNLuaE80CGYn8Oeg",
                AccessTokenSecret = "RByLfxQ563S73FBFyd0HdB8a6jgxsKceVzztWLs63KZ6n"
            };
        }

        public IEnumerable<Tweet> GetTweets()
        {
            var tweets = 
                Auth.ExecuteOperationWithCredentials(_creds, () => Timeline.GetUserTimeline("xero", 10)).ToList();

            if (tweets.Any()) // If there's no tweets coming back, we won't map anything. 
            {
                return tweets.Select(t => new Tweet
                {
                    Id = t.Id,
                    Text = t.Text
                });
            }

            return new List<Tweet>();
        }
    }
}