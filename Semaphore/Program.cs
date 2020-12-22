using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphore
{
    //this is used to solve the synchronization between threads problem
    // the semaphore protects certain process asynchronously
    public class Program
    {
        static HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
        static SemaphoreSlim gate = new SemaphoreSlim(20); // allow 20 calls to go through the gate at a time ~

        static void Main(string[] args)
        {
            Task.WaitAll(CreateCalls().ToArray());
            Console.ReadLine();
        }

        public static IEnumerable<Task> CreateCalls()
        {
            for (int i = 0; i < 500; i++)
            {
                yield return CallGoogle();
            }
        }

        public static async Task CallGoogle()
        {
            try
            {
                await gate.WaitAsync();
                var response = await client.GetAsync("https://google.com");
                gate.Release();
                Console.WriteLine(response.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}