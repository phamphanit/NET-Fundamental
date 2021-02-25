using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Asynchronous
{
  
    class Program
    {
        static async Task Main(string[] args)
        {
            Method3();
            //Method2();
            Task<int> task2 = new Task<int>(Method2);
            task2.Start();
            Method4();
             Method1();
            //Method3().Wait();
            //var result = await task2;
            var result = await task2;
            Console.WriteLine(result);
            //Method2();


        }
        public static async Task Method1()
        {
            Console.WriteLine("Start method 1.....");

            Action task = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(" Method 1");
                    // Do something
                    Task.Delay(100).Wait();
                }
            };


            Task task1 = new Task(task);

            task1.Start();
            await task1;
            Console.WriteLine("Hoan thanh method 1");
        }
        public static int Method2()
        {
            Console.WriteLine("Start method 2.....");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" Method2");
                // Do something
                Task.Delay(100).Wait();
            }
            Console.WriteLine("Hoan thanh method 2");
            return 2;

        }

        public static async Task Method4()
        {
            Console.WriteLine("Start method 4.....");

            Action task = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(" Method 4");
                    // Do something
                    Task.Delay(100).Wait();
                }
            };


            Task task1 = new Task(task);

            task1.Start();
            //await task1;
            //await Task.Run(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine(" Method 4");
            //        // Do something
            //        Task.Delay(100).Wait();
            //    }
            //});
            Console.WriteLine("Hoan thanh method 4");
        }
        public static async Task Method3()
        {
            Console.WriteLine("Start method 3.....");

            Action task = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(" Method 3");
                    // Do something
                    Task.Delay(100).Wait();
                }
            };


            Task task1 = new Task(task);

            task1.Start();
            await task1;
            Console.WriteLine("Hoan thanh method 3");
        }

    }
}
