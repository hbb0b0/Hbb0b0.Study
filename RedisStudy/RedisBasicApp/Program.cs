using System;
using StackExchange.Redis;
using Newtonsoft.Json;
//using System.Configuration.Assemblies
namespace RedisBasicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConfigManager
            BasicSample basicSample = new BasicSample();
            //basicSample.HashTest();
            basicSample.HashIncrement();
            Console.Read();
        }
    }
}
