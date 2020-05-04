using System;
using System.Threading.Tasks;
using System.Timers;

namespace AsyncAwait
{
    class Program
    {
        static string fileDirectory = @"DIRECTORY_PATH\";

        static TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            FilePolling poll = new FilePolling();

            poll.CheckFileIDAsync(fileDirectory, "hello");
            
            Console.WriteLine("This is outside of async codes");

            Console.ReadKey();
        }

    }
}
