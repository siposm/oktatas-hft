using System.Text.Json;

namespace _05_JSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // JSON fájl beolvasása
            string filePath = "user-tweets.json";
            string jsonContent = File.ReadAllText(filePath);

            // JSON deszerializálása C# objektumokká
            var users = JsonSerializer.Deserialize<List<User>>(jsonContent);

            // 1. Minden felhasználó és a flagelt tweetjeik listázása
            var flaggedUsers = users
                .Select(user => new
                {
                    UserName = user.UserName,
                    FlaggedTweets = user.Tweets
                        .Where(tweet => tweet.Flagged == true)
                        .Select(tweet => tweet.Content)
                })
                .Where(u => u.FlaggedTweets.Any());

            Console.WriteLine("Felhasználók flagelt tweetekkel:");
            foreach (var user in flaggedUsers)
            {
                Console.WriteLine($"Felhasználó: {user.UserName}");
                foreach (var tweet in user.FlaggedTweets)
                {
                    Console.WriteLine($" - Tweet: {tweet}");
                }
            }

            Console.WriteLine("\n------\n");

            // 2. Az összes tweet listázása, amelyek 2020 után íródtak
            var recentTweets = users
                .SelectMany(user => user.Tweets)
                .Where(tweet => tweet.Year > 2020)
                .Select(tweet => new
                {
                    Content = tweet.Content,
                    Year = tweet.Year
                });

            Console.WriteLine("Tweetek 2020 után:");
            foreach (var tweet in recentTweets)
            {
                Console.WriteLine($"Tweet (év: {tweet.Year}): {tweet.Content}");
            }
        }
    }
}
