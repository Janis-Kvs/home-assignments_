# Practical task "Reddit API"

Reddit is a social network that provides users with internet’s most popular content. The content is provided in “threads” that are cataloged into “subreddits”. Each thread has comments and a rating.

Reddit exposes a public API that is documented here: https://www.reddit.com/dev/api/

## Goal

To make a “proxy” WEB API that returns the current best 5 threads and 5 best comments for each of the threads. Your API should return the data in following JSON format:

```
{
    "threads": [
        {
            "title": "first threads title",
            "comments": [
                "first threads first comment",
                "first threads second comment"
            ]
        },
        {
            "title": "second threads title",
            "comments": [
                "second threads first comment",
                "second threads second comment"
            ]
        }
    ]
}
```
## Requirements

- To gain this data you must use the following reddit API methods:
    - https://www.reddit.com/dev/api/#GET_best for retrieving best threads (full url: https://oauth.reddit.com/best)
    - https://www.reddit.com/dev/api/#GET_comments_{article} for retrieving comments for a thread (full url: https://oauth.reddit.com/r/{subreddit}/comments/{thread_id})
- For authentication reddit requires OAuth 2 (and for you to create a user) and for this specific task you must use the “client credentials” flow as described in https://github.com/reddit-archive/reddit/wiki/OAuth2 at “Application Only OAuth” section.
- The solution must include full source code and instruction on how to build.