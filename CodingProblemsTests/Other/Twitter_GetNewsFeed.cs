namespace CodingProblemsTests.Other;

public class Twitter_GetNewsFeed
{
    [Theory]
    [InlineData(null, null, null, 1, new int[0])]
    [MemberData(nameof(TestData))]
    public void Works((int userId, int followeeId)[] follows, (int userId, int tweetId)[] tweets,
        (int userId, int followee)[] unFollows, int userToRequest, int[] expectedFeed)
    {
        Twitter sut = new();

        if (follows != null)
        {
            foreach ((int userId, int followeeId) in follows)
                sut.Follow(userId, followeeId);
        }

        if (tweets != null)
        {
            foreach ((int userId, int tweetId) in tweets)
                sut.PostTweet(userId, tweetId);
        }

        if (unFollows != null)
        {
            foreach ((int userId, int followeeId) in unFollows)
                sut.Unfollow(userId, followeeId);
        }

        IList<int> feed = sut.GetNewsFeed(userToRequest);

        feed.Count.Should().BeLessThanOrEqualTo(10);

        if (expectedFeed != null)
            feed.Should().Equal(expectedFeed);
    }

    public static TheoryData<(int userId, int followeeId)[], (int userId, int tweetId)[], (int userId, int followee)[], int, int[]> TestData =>
        new()
        {
            {
                null,
                new[] { (1, 5) },
                null,
                1,
                new[] { 5 }
            },
            {
                new[] { (1, 2), (1, 2) },
                new[] { (1, 5), (2, 6) },
                null,
                1,
                new[] { 6, 5 }
            },
            {
                new[] { (1, 2) },
                new[] { (1, 5), (2, 6) },
                new[] { (1, 2) },
                1,
                new[] { 5 }
            },
            {
                null,
                new[] { (1, 5), (2, 6) },
                new[] { (1, 2) },
                1,
                new[] { 5 }
            },
            {
                new[] { (1, 2) },
                new[] { (1, 6), (2, 5) },
                null,
                1,
                new[] { 5, 6 }
            },
            {
                new[] { (1, 2), (1, 3), (1, 4), (1, 10) },
                generateTweets(),
                null,
                1,
                null
            },
        };

    private static (int userId, int tweetId)[] generateTweets()
    {
        List<(int userId, int tweetId)> tweets = new();

        int maxTweets = 1000000;
        int tweetCounter = maxTweets;

        for (int tw = 0; tw < maxTweets; tw++)
            tweets.Add((tw % 20, tweetCounter--));

        return tweets.ToArray();
    }
}
