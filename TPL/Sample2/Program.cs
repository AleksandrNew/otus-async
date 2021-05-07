using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    interface ISomeService
    {
        Task<IEnumerable<string>> GetDataAsync();

        Task SetData();
    }

    public class MockSomeService : ISomeService
    {
        public Task<IEnumerable<string>> GetDataAsync()
        {
            var data = new List<string>()
            {
                "line",
                "line",
                "line",
                "line"
            };

            return Task.FromResult(data.AsEnumerable());
        }

        public Task SetData()
        {
            return Task.CompletedTask;
        }
    }
}
