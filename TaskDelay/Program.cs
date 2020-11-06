using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDelay
{
    class Program
    {
        static Task WithoutAwait()
        {
            Console.WriteLine("Not waiting");
            return Task.Delay(1000);
        }

        static async Task WithAwait()
        {
            Console.WriteLine("Waiting");
            await Task.Delay(1000);
        }

        static void Main(string[] args)
        {
            var withoutAwaitTask = new Task(() =>
            {
                for (int i = 0; i < 10; ++i)
                    WithoutAwait();
            });

            withoutAwaitTask.RunSynchronously();

            var withAwaitTask = new Task(async () =>
            {
                for (int i = 0; i < 10; ++i)
                    await WithAwait();
            });

            withAwaitTask.RunSynchronously();

            Thread.Sleep(10000);
        }
    }
}
