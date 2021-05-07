using System;
using System.Threading.Tasks;

namespace Sample4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new SomeService();
            await service;
        }
    }
}
