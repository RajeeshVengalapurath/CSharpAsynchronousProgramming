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
            await WaitForAllTasksToFinish();
            Console.WriteLine("Main end");
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
            //Console.ReadKey();
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
            //Console.ReadKey();
        }
    }
}
