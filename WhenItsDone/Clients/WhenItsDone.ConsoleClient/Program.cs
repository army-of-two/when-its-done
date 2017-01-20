using System;
using System.Threading.Tasks;

namespace WhenItsDone.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var asyncResult = Program.AsyncTest();
            asyncResult.ContinueWith((task) =>
            {
                // this will only be executed if the 
                // operation is completed BEFORE the console app has finished execution.
                // thus counter to 100
                Console.WriteLine($"Counter - resulting value - Async - {task.Result}");
            });

            var syncResult = Program.SyncTest();
            Console.WriteLine($"Counter - value - Sync - {syncResult.Result}");
        }

        private static Task<long> AsyncTest()
        {
            long counter = 0;
            var runTask = Task.Run(() =>
             {
                 for (long i = 0; i < 100; i++)
                 {
                     counter++;
                 }

                 return counter;
             });

            // This is executed before the task has even been assigned a thread.
            Console.WriteLine($"Counter - initial value - Async - {counter}");

            return runTask;
        }

        private async static Task<long> SyncTest()
        {
            var counter = 0;
            var result = await Task.Run(() =>
             {
                 // Add zeroes for increased effect
                 for (long i = 0; i < 999999999; i++)
                 {
                     counter++;
                 }

                 return counter;
             });

            // This is executed AFTER the task is completed
            Console.WriteLine($"Counter - initial value - Sync (cw afer await) - {counter}");

            return result;
        }
    }
}
