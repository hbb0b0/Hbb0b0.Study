using System;

namespace StockPricesSample
{
    class Program
    {
        static void Main(string[] args)
        {
            MyProgram.Run();

            Console.Read();
        }

        static void  CallAsyncShowPrice()
        {
            Console.WriteLine("main start");
            ShowPriceAsync();
            Console.WriteLine("main end");
            Console.ReadLine();
        }

      static   async void ShowPriceAsync()
        {
            Console.WriteLine($"ShowPriceAsync begin");
            string companyID = "MSFT";
            decimal price = await new StockPrices().GetStockPriceForAsync(companyID);

            Console.WriteLine($"companyId:{companyID} price:{price}");

            Console.WriteLine($"ShowPriceAsync end");
        }
    }
}
