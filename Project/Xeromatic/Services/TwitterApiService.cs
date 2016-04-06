using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweetinvi.Core.Interfaces;

namespace Xeromatic.Services
{
    public class TwitterApiService
    {
        // Get keys from: https://apps.twitter.com
        // Wiki for tweetinvi: https://github.com/linvi/tweetinvi/wiki

        readonly TwitterCredentials _creds;

        public TwitterApiService()
        {
            _creds = new TwitterCredentials
            {
                ConsumerKey = "Add your ConsumerKey here",
                ConsumerSecret = "Add your ConsumerSecret here",
                AccessToken = "Add your AccessToken here",
                AccessTokenSecret = "Add your AccessTokenSecret here"
            };
        }

        public IEnumerable<ITweet> GetTweets()
        {
            var tweets = Auth.ExecuteOperationWithCredentials(_creds, () =>
            {
                return Timeline.GetHomeTimeline();
            });

            return tweets;
        }

    }
}