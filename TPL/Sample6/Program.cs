using System;
using System.Threading.Tasks;

namespace Sample6
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var data = await PostProcessDataAsync();
            Console.WriteLine(data);
        }

        private static async Task<string> PostProcessDataAsync()
        {
            return await ProcessDataAsync();
        }

        private static async Task<string> ProcessDataAsync()
        {
            return await GetDataAsync();
        }

        private static async Task<string> GetDataAsync()
        {
            return await Task.Run(() => "Data");
        }
    }
}
