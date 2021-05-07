using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Sample3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var delay = 1000;
            await delay;
        }
    }

    public static class Int32Extensions
    {
        public static TaskAwaiter GetAwaiter(this int value)
        {
            return Task.Delay(value).GetAwaiter();
        }
    }
}
