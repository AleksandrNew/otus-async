using System;
using System.Threading.Tasks;

namespace Sample5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetDataAsync(1000, 2000).Wait();
        }

        static async Task GetDataAsync(int a, int b)
        {
            Console.WriteLine("Getting data...");
            await Task.Delay(a);
            await Task.Delay(b);
        }
    }
}
