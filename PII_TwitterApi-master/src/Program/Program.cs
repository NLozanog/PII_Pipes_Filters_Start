using System;
using System.Threading.Tasks;

namespace TwitterUCU
{
    class Program
    {
        static void Main(string[] args)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("","//luke2.jpg"));
        }
    }
}