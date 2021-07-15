using System;

namespace CrawlSample
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string url = "https://www.cnblogs.com/";
            MyCrawl myCrawl = new MyCrawl();
            myCrawl.Test();

            Console.Read();
        }

        
    }
}
