using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Channels
{
    // Channels => they are mainly used to solve the producer-consumer problem
    // Something produces 'x', something else has to consume this 'x' => use a channel

    // useful with DI services when the service lifetime expires before the final tasks are complete ...
    // channels => put a message of what you wanna send in a channel and then when a service is ready, it can pick it up

    // also you might wanna limit the amount of tasks that get processed at the same time, in order to keep the server fast
    // channels also help with that, they implement a queue

    // Channels comprise of 2 things => you wanna read and you wanna write off a channel (read must be async, reader should not block the queue as it can receive items from the 'writer')
    // sempahore is needed , once you push an item you can say 'come on, read' and gates are required
    // They act esentially like queues, but you regulate how many items you have in the queue, who can read from the queue and when you can read it off a queue in an async manner

    class Program
    {
        static void Main()
        {
            var channel = new Channel<string>();
            Task.WaitAll(Consumer(channel), Producer(channel));
        }




        public interface IRead<T> 
        {
            // wait to read from a queue, when complete exit 
            Task<T> Read();
            bool IsComplete();
        }
        public interface IWrite<T> 
        {
            // push something onto a queue, once it's finished mark it complete
            void Push(T msg);
            void Complete();
        }


        public class Channel<T> : IRead<T>, IWrite<T>
        {
            private bool Finished;
            private SemaphoreSlim flag;
            private ConcurrentQueue<T> Queue;
            public Channel()
            {
                Queue = new ConcurrentQueue<T>();
                flag = new SemaphoreSlim(0);
            }


            public void Complete()
            {
                Finished = true;
            }

            public bool IsComplete()
            {
                return Finished && Queue.IsEmpty;
            }

            public void Push(T msg)
            {
                Queue.Enqueue(msg);
                flag.Release();
            }

            public async Task<T> Read()
            {
                await flag.WaitAsync();

                if (Queue.TryDequeue(out var msg))
                {
                    Console.WriteLine(msg);
                }

                return default;
            }
        }

        public static Task Producer (IWrite<string> writer)
        {
            for (int i=0; i<100; i++)
            {
                writer.Push(i.ToString());
                Task.Delay(100).GetAwaiter().GetResult();
            }
            writer.Complete();
            return Task.CompletedTask;
        }

        public static async Task Consumer (IRead<string> reader)
        {
            while (!reader.IsComplete())
            {
                var msg = await reader.Read();
                Console.WriteLine("msg");
            }
        }
    }
}
