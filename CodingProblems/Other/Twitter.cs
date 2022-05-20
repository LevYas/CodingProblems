using System;
using System.Collections.Generic;

namespace CodingProblems.Other;

// 355. Design Twitter
// Design a simplified version of Twitter where users can post tweets, follow/unfollow another user,
//      and is able to see the 10 most recent tweets in the user's news feed.
// 
// Implement the Twitter class:
//  - Twitter() Initializes your twitter object.
//  - void postTweet(int userId, int tweetId) Composes a new tweet with ID tweetId by the user userId.
//          Each call to this function will be made with a unique tweetId.
//  - List<Integer> getNewsFeed(int userId) Retrieves the 10 most recent tweet IDs in the user's news feed.
//          Each item in the news feed must be posted by users who the user followed or by the user themself.
//          Tweets must be ordered from most recent to least recent.
//  - void follow(int followerId, int followeeId) The user with ID followerId started following the user with ID followeeId.
//  - void unfollow(int followerId, int followeeId) The user with ID followerId started unfollowing the user with ID followeeId.
// https://leetcode.com/problems/design-twitter/

public class Twitter
{
    private int _rank = Int32.MaxValue;

    private record Tweet(int Id, int Rank)
    {
        public Tweet? PreviousTweet { get; set; }
    }

    private readonly Dictionary<int, HashSet<int>> _followerToFollowees = new();
    private readonly Dictionary<int, Tweet> _userToTweets = new();
    
    public void PostTweet(int userId, int tweetId)
    {
        Tweet newTweet = new(tweetId, _rank--);

        if (_userToTweets.TryGetValue(userId, out Tweet? lastTweetSoFar))
        {
            newTweet.PreviousTweet = lastTweetSoFar;
            _userToTweets[userId] = newTweet;
        }
        else
            _userToTweets.Add(userId, newTweet);
    }

    public IList<int> GetNewsFeed(int userId)
    {
        List<int> usersToQuery = new() { userId };

        if (_followerToFollowees.ContainsKey(userId))
            usersToQuery.AddRange(_followerToFollowees[userId]);

        PriorityQueue<Tweet, int> topTweets = new(10);

        foreach (int u in usersToQuery)
        {
            if (_userToTweets.TryGetValue(u, out Tweet? t))
                topTweets.Enqueue(t, t.Rank);
        }

        List<int> result = new();

        while (result.Count < 10 && topTweets.Count > 0)
        {
            Tweet last = topTweets.Dequeue();
            result.Add(last.Id);
            if (last.PreviousTweet != null)
                topTweets.Enqueue(last.PreviousTweet, last.PreviousTweet.Rank);
        }

        return result;
    }

    public void Follow(int followerId, int followeeId)
    {
        _followerToFollowees.TryAdd(followerId, new HashSet<int>());
        _followerToFollowees[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (!_followerToFollowees.TryGetValue(followerId, out HashSet<int> followees))
            return;

        if (followees.Contains(followeeId))
            followees.Remove(followeeId);
    }
}
