using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AsyncBreakfast
{
    class Program
    {
        // <SnippetMain>
        static async Task Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Coffee cup = PourCoffee();
            Console.WriteLine("1. coffee is ready");
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            // <SnippetAwaitAnyTask>
            var allTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished == eggsTask)
                {
                    Console.WriteLine("2. eggs are ready");
                }
                else if (finished == baconTask)
                {
                    Console.WriteLine("3. bacon is ready");
                }
                else if (finished == toastTask)
                {
                    Console.WriteLine("4. toast is ready");
                }
                allTasks.Remove(finished);
            }
            Juice oj = PourOJ();
            Console.WriteLine("5. oj is ready");
            Console.WriteLine("Breakfast is ready!");
            Console.WriteLine("Finished in {0} sec.", sw.ElapsedMilliseconds / 1000.0);
            Console.ReadLine();
            // </SnippetAwaitAnyTask>

            async Task<Toast> MakeToastWithButterAndJamAsync(int number)
            {
                var toast = await ToastBreadAsync(number);
                ApplyButter(toast);
                ApplyJam(toast);
                return toast;
            }
        }
        // </SnippetMain>

        private static Juice PourOJ()
        {
            Console.WriteLine("5. Pouring Orange Juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) => Console.WriteLine("4. Putting jam on the toast");

        private static void ApplyButter(Toast toast) => Console.WriteLine("4. Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("4. Putting a slice of bread in the toaster");
            Console.WriteLine("4. Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("4. Remove toast from toaster");
            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"3. putting {slices} of bacon in the pan");
            Console.WriteLine("3. cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("3. flipping a slice of bacon");
            Console.WriteLine("3. cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("3. Put bacon on plate");
            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("2. Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"2. cracking {howMany} eggs");
            Console.WriteLine("2. cooking the eggs ...");
            await Task.Delay(3000);
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