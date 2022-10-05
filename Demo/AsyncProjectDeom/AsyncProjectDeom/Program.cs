using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace AsyncProjectDeom
{
    class Program
    {
        static int ExpensiveOne()
        {
            Console.WriteLine("\nExpensiveOne() is executing.");
            return 1;
        }

        static long ExpensiveTwo(string input)
        {
            Console.WriteLine("\nExpensiveTwo() is executing.");
            return (long)input.Length;
        }

        static readonly CancellationTokenSource s_cts = new CancellationTokenSource();
        static async Task Main(string[] args)
        {
            LazyValue<int> lazyOne = new LazyValue<int>(ExpensiveOne);
            LazyValue<long> lazyTwo = new LazyValue<long>(() => ExpensiveTwo("apple"));

            //Console.WriteLine(lazyOne.Value);
            //Console.WriteLine(lazyTwo.Value);



            Task<int> downloading = DownloadDocsMainPageAsync();
            Task<int> printDot = PrintDot();
            Console.WriteLine($"{nameof(Main)}: Launched downloading.");

            //int bytesLoaded = await downloading;
            //Console.WriteLine($"{nameof(Main)}: Downloaded {bytesLoaded} bytes.");
            var taskList = new List<Task<int>> { downloading, printDot };
            
                Task<int> finishedTask = await Task.WhenAny(taskList);
                if (finishedTask == downloading)
                {
                    int bytesLoaded = await finishedTask;
                    Console.WriteLine($"{nameof(Main)}: Downloaded {bytesLoaded} bytes.");
                    s_cts.Cancel();
                }
        }

        private static async Task<int> PrintDot()
        {
            while (true)
            {
                Console.Write(".");
                await Task.Delay(100);
            }
            return 1;
        }

        private static async Task Test2Long()
        {
            Task<int> task1 = Long1();
            Task<int> task2 = Long2();
            int r1 = await task1;
            Console.WriteLine($"output of r1: {r1}");
        }

        private static void TestLongShort()
        {
            Task<int> result = LongProcess();

            ShortProcess();

            //var val = await result; // wait untile get the return value

            //Console.WriteLine("Result: {0}", val);
        }

        static async Task<int> LongProcess()
        {
            Console.WriteLine("LongProcess Started");

            await Task.Delay(4000); // hold execution for 4 seconds

            Console.WriteLine("LongProcess Completed");

            return 10;
        }

        static void ShortProcess()
        {
            Console.WriteLine("ShortProcess Started");

            //do something here

            Console.WriteLine("ShortProcess Completed");
        }

        static async Task<int> Long1()
        {
            for (int i = 0; i < 50; i++)
            {
                await Task.Delay(10);
                Console.WriteLine($"Long 1 : {i}");
            }
            return 1;
        }
        static async Task<int> Long2()
        {
            for (int i = 0; i < 50; i++)
            {
                await Task.Delay(10);
                Console.WriteLine($"Long 2 : {i}");
            }
            return 2;
        }

        private static async Task<int> DownloadDocsMainPageAsync()
        {
            Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: About to start downloading.");

            var client = new HttpClient();
            byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/en-us/");

            Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: Finished downloading.");
            return content.Length;
        }
    }
}

