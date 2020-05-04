using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Application : IApplication
    {
        IFilePolling _filepolling;
        static string fileDirectory = @"C:\Users\wongh\Documents\test";

        public Application(IFilePolling filePolling)
        {
            _filepolling = filePolling;
        }

        public void Run()
        {
            Console.WriteLine("Start");

            Task<string> documentid = _filepolling.CheckFileIDAsync(fileDirectory, "hello");

            Console.WriteLine("This runs outside of async codes");

            Task.WaitAll(documentid);

            Console.WriteLine("document id is : " + documentid.Result);

            Console.ReadKey();
        }
    }
}
