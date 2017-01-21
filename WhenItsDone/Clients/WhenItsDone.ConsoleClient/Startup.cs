﻿using System;
using System.Threading.Tasks;

namespace WhenItsDone.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var asyncResult = Startup.AsyncTest();
            asyncResult.ContinueWith((task) =>
            {
                // this will only be executed if the 
                // operation is completed BEFORE the console app has finished execution.
                // side effect of having a console app, thus counter is set to 100
                Console.WriteLine($"Counter - resulting value - Async - {task.Result}");
            });

            var syncResult = Startup.SyncTest();
            Console.WriteLine($"Counter - resulting value - Sync - {syncResult.Result}");
        }

        private static Task<long> AsyncTest()
        {
            long counter = 0;
            var runTask = Task.Run(() =>
             {
                 for (long i = 0; i < 100000; i++)
                 {
                     counter++;
                 }

                 return counter;
             });

            // This is executed before the task has even been assigned a thread (on my pc at least , always prints 0).
            Console.WriteLine($"Counter - initial value - Async - {counter}");

            return runTask;
        }

        private async static Task<long> SyncTest()
        {
            long counter = 0;
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
            // and BEFORE the result is returned to the Main method for printing.
            // Therefore this is executed syncronously.
            Console.WriteLine($"Counter - initial value - Sync - {counter}");

            return result;
        }
    }
}