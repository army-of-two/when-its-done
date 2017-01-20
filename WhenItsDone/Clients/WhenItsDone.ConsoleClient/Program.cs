using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenItsDone.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            Program.AsyncTest();
            var result = Program.SyncTest();
            Console.WriteLine(result.Result);
        }

        private static void AsyncTest()
        {
            var counter = 0;
            Task.Run(() =>
            {
                for (long i = 0; i < 999999999999; i++)
                {
                    counter++;
                }
            });

            Console.WriteLine(counter);
        }

        private async static Task<long> SyncTest()
        {
            var counter = 0;
            return await Task.Run(() =>
             {
                 for (long i = 0; i < 999999999999; i++)
                 {
                     counter++;
                 }

                 return counter;
             });
        }
    }
}
