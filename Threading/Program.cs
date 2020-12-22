using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th = new Thread(() =>
            {
                Console.WriteLine("test");
            });

            th.Start();

            
            Task t = Task.Factory.StartNew(() =>
            {
               Console.WriteLine("test");
            });

            // check what thread we're on
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

        /*
            difference between using a Thread and using a Task !    Ultimately the exact same thing ... 
            Task is backed by a ThreadPool of real Threads (same performance once it's warmed up) - better performance wise
            Thread has a stack size, context, lots of overhead ... the Pool of thread objects sitting idly allows you to reuse them and save cold boot time

            Thread.Sleep() is sometimes based, due to context switching (which is expensive, you want to keep 1 context for as long as possible)
            The OS can only run 1 Task per core (simplified), so the OS has to time-slice all of the tasks/threads appropriately
            If you have more Threads than you have cores, context switching occurs (which is expensive) 
            Example => OS knows of 30 threads, has 2 cores, can only run 2 timeslices at a time but 30 timeslices that need to run at a time
                    => OS needs to keep switching in & out of contextes in the Kernel to get between all of these Threads ~ 

            So Threads and Tasks are exactly the same thing if you're using your own thread pool
            If you wanna start up a Thread to do a small block of code for fire & forget operations => use task, let it go to default thread pool
            If you use a background Thread to keep it alive for the entire program's length ... if it operatoes for a long time, spin up a dedicated Thread no problem
            But tasks are for fire & forget, quick operations ... otherwise they might tie up threads in the threadpool if left for too long time, doing weird stuff
        */
        }
    }
}
