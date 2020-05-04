using System;
using System.Threading.Tasks;
using System.Timers;

namespace AsyncAwait
{
    class Program
    {
        static string fileDirectory = @"DIRECTORY_PATH";

        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            FilePolling poll = new FilePolling();

            Task<string> documentid = poll.CheckFileIDAsync(fileDirectory, "hello");
            
            Console.WriteLine("This runs outside of async codes");

            Task.WaitAll(documentid);
            Console.WriteLine("document id is : " + documentid.Result);

            Console.ReadKey();
        }

    }
}
