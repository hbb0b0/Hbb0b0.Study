using System;
using System.Threading.Tasks;

namespace CoffeExampleWithTAP
{
    class Program
    {
        static void Main(string[] args)
        {
            DoBreakfast();
            Console.ReadLine();
        }

        public static  void DoBreakfast()
        {
            /*
            Coffee cup = await PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = await FryEggs(2);
            Console.WriteLine("eggs are ready");
            */
            /*
            var coffeeTask = PourCoffee();
            var eggTask = FryEggs(2);

            var cup = await coffeeTask;

            var egg = await eggTask;
            */

            AsyncPourCoffee();
            AsyncFryEggs();

            Bacon bacon = FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");

          
        }

        private static Juice PourOJ()
        {

            Console.WriteLine("Pouring orange juice");
            return new Juice();

        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async void AsyncFryEggs()
        {
            Console.WriteLine("AsyncFryEggs End");
            Egg egg =    await FryEggs(2);
            Console.WriteLine("AsyncFryEggs End");
        }

        private static async void AsyncPourCoffee()
        {
            Console.WriteLine("AsyncPourCoffee End");
            Coffee bacon = await PourCoffee();
            Console.WriteLine("AsyncPourCoffee End");
        }



        private static async Task<Egg> FryEggs(int howMany)
        {
            Console.WriteLine("FryEggs reading...");
            return await Task.Run(() =>
            {
                Console.WriteLine("Warming the egg pan...");
                Task.Delay(3000).Wait();
                Console.WriteLine($"cracking {howMany} eggs");
                Console.WriteLine("cooking the eggs ...");
                Task.Delay(3000).Wait();
                Console.WriteLine("Put eggs on plate");

                return new Egg();
            });
            
        }

        private static async Task<Coffee> PourCoffee()
        {
            Console.WriteLine("Pouring coffee reading...");
            return    await Task.Run(() =>
            {
                Console.WriteLine("Pouring coffee start");
                Task.Delay(3000).Wait();
                Console.WriteLine("Pouring coffee running");
                Task.Delay(3000).Wait();
                Console.WriteLine("Pouring coffee end");
                return new Coffee();
            });

        }
    }
}
