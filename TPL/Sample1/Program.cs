using System;
using System.Threading.Tasks;

namespace Sample1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var result = await DoSomethingAsync(4, 5);
            Console.WriteLine(result);
        }

        static Task<int> DoSomethingAsync(int a, int b)
        {
            Console.WriteLine("Doing...");
            Task.Delay(1000).Wait();
            var c = a * b;

            return Task.FromResult(c);
        }
    }
}
