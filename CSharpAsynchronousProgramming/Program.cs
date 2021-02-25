using System;
using System.Threading.Tasks;

namespace CSharpAsynchronousProgramming
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await StartTasksConcurrently();
            //await StartTasksSequentially();
            //await WaitForAllTasksToFinish();
            int value = await GetIntValueTask();
            Console.WriteLine(value);
        }
        static async Task StartTasksConcurrently()
        {
            var task1 = Task1();
            var task2 = Task2();

            await task1;
            await task2;
        }
        static async Task StartTasksSequentially()
        {
            await Task1();
            await Task2();
        }
        static async Task WaitForAllTasksToFinish()
        {
            var task1 = Task1();
            var task2 = Task2();

            await Task.WhenAll(task1, task2);
        }
        static async Task Task1()
        {
            Console.WriteLine("Task1 start");
            await Task.Run(() => {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine("Task1 i=" + i.ToString());
                }
            });
            Console.WriteLine("Task1 end");
        }
        static async Task Task2()
        {
            Console.WriteLine("Task2 start");
            await Task.Run(() => {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine("Task2 i=" + i.ToString());
                }
            });
            Console.WriteLine("Task2 end");
        }
        /// <summary>
        /// Starting with C# 7.0, an async method can return any type that has an accessible GetAwaiter method
        /// </summary>
        /// <returns></returns>
        static async ValueTask<int> GetIntValueTask()
        {
            int r=9;
            return r;
        }
    }
}
