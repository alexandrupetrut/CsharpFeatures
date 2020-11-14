using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharp7.Library.CSharp7._1.a._async_main
{
    public class Program
    {
        /* PREVIOUSLY - couldn't decorate main function with async and call it somewhere else without GetAwaiter ...
        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }
        public static async Task MainAsync()
        {
            var result = await new HttpClient().GetStringAsync("http://www.google.com");
            Console.WriteLine(result);
        }
        */

        // CURRENTLY
        public static async Task<int> Main()
        {
            var result = await new HttpClient().GetStringAsync("http://www.google.com");
            Console.WriteLine(result);
            return 0;
        }
    }
}
