using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        // <SnippetMain>
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Coffee cup = PourCoffee();
            Console.WriteLine("1. coffee is ready");
            Egg eggs = FryEggs(2);
            Console.WriteLine("2. eggs are ready");
            Bacon bacon = FryBacon(3);
            Console.WriteLine("3. bacon is ready");
            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("4. toast is ready");
            Juice oj = PourOJ();
            Console.WriteLine("5. oj is ready");

            Console.WriteLine("Breakfast is ready!");
            Console.WriteLine("Finished in {0} sec.", sw.ElapsedMilliseconds / 1000.0);
            Console.ReadLine();
        }
        // </SnippetMain>

        private static Juice PourOJ()
        {
            Console.WriteLine("5. Pouring Orange Juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) => Console.WriteLine("4. Putting jam on the toast");

        private static void ApplyButter(Toast toast) => Console.WriteLine("4. Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("4. Putting a slice of bread in the toaster");
            Console.WriteLine("4. Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("4. Remove toast from toaster");
            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"3. putting {slices} of bacon in the pan");
            Console.WriteLine("3. cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("3. flipping a slice of bacon");
            Console.WriteLine("3. cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("3. Put bacon on plate");
            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("2. Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"2. cracking {howMany} eggs");
            Console.WriteLine("2. cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("2. Put eggs on plate");
            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("1. Pouring coffee");
            return new Coffee();
        }
    }
}