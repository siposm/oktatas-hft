using System.Xml.Linq;

namespace _04_XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Az XML fájl beolvasása
            string filePath = "user-tweets.xml";
            XDocument xmlDoc = XDocument.Load(filePath);

            // 1. Minden felhasználó és a flagelt tweetjeik listázása
            var flaggedUsers = xmlDoc.Descendants("User")
                .Select(user => new
                {
                    UserName = user.Element("UserName").Value,
                    FlaggedTweets = user.Descendants("Tweet")
                        .Where(tweet => tweet.Element("Flagged").Value == "true")
                        .Select(tweet => tweet.Element("Content").Value)
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
            var recentTweets = xmlDoc.Descendants("Tweet")
                .Where(tweet => int.Parse(tweet.Element("Year").Value) > 2020)
                .Select(tweet => new
                {
                    Content = tweet.Element("Content").Value,
                    Year = tweet.Element("Year").Value
                });

            Console.WriteLine("Tweetek 2020 után:");
            foreach (var tweet in recentTweets)
            {
                Console.WriteLine($"Tweet (év: {tweet.Year}): {tweet.Content}");
            }
        }
    }
}
