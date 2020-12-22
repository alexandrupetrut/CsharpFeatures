using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Async_Await
{
    // Making a cup of tea (analogy)
    class Program
    {
        // async => Task is the bridge between your code and the State Machine that 'async' creates and 'await' is the checkpoints within the State Machine

        static /*void*/ async Task Main(string[] args)  // => async Task instead of void => now Main isn't a function, it's an object (of class Main that inherits from IAsyncStateMachine)
                                                        // for async Task, the variables from a method become object fields preserved as states of the new state machine object
                                                        // the things that we do with our variables is now put in a special class method of this object => private void MoveNext()
                                                        // MoveNext() is checkpointed by the 'await' keyword, as in the row after await is present gets a subsequent new additional state
                                                        // when we create the state machine, we put it in memory (RAM), it's not garbage collected ... the .Net threadpool can find it in memory
        
        {
            // parts or states as in how many times is it going to be called again (state num = 0; num = 1; num = -2 in case of exception ... for the 2 awaiters - seen in IL)

            // part 1
            var client = new HttpClient();
            var firstTask = await client.GetStringAsync("https://google.com");

            // part 2
            int a = 0;
            for (int i = 0; i< 1_000_000; i++)
            {
                a = i + 1;
            }
            var secondTask = await client.GetStringAsync("https://google.com");

            // part 3
            Console.WriteLine("Hello World!");
        }

    }
}
