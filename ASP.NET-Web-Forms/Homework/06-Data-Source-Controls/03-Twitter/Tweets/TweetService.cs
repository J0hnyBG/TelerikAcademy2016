using System.Collections.Generic;
using System.Linq;

using Tweetinvi;

using _03_Twitter.Models;

namespace _03_Twitter.Tweets
{
    public class TweetService
    {
        public IEnumerable<SimpleTweet> GeSimpleTweets(string userName)
        {
            if ( string.IsNullOrWhiteSpace(userName) )
            {
                return new List<SimpleTweet>();
            }

            var t = Timeline.GetUserTimeline(userName);
            var displayName = t.FirstOrDefault()?.CreatedBy?.Name;
            var imgUrl = t.FirstOrDefault()?.CreatedBy?.ProfileImageUrl;
            var tweets = t.Select(tw => new SimpleTweet()
            {
                CreatedAt = tw.CreatedAt,
                FullText = tw.FullText,
                DisplayName = displayName,
                Url = tw.Url,
                ImgUrl = imgUrl
            });

            return tweets;
        }
    }
}