using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Common;

namespace Sample1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            await foreach (var item in DoSometingAsync())
            {
                Console.WriteLine(item);
            }

            sw.Stop();
        }

        private static async IAsyncEnumerable<int> DoSometingAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(2000);
                yield return i;
            }
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            Toast toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }
        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Намазываем джем на тост");

        private static void  ApplyButter(Toast toast) =>
            Console.WriteLine("Намазываем масло на тост");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            throw new Exception("тостер сломался");
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Помещаем хлеб в тостер");
            }
            Console.WriteLine("Включаем тостер...");
            await Task.Delay(5000);
            Console.WriteLine("Вынимаем тосты из тостера");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            throw new Exception("кончился бекон");
            Console.WriteLine($"Кладем {slices} кусосков бекона на сковороду");
            Console.WriteLine($"Жарим {slices} кусосков бекона...");
            await Task.Delay(5000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Переворачиваем кусок бекона");
                await Task.Delay(2000);
            }

            Console.WriteLine("Накладываем бекон на тарелку");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            throw new Exception("не сковороды");
            Console.WriteLine("Разогреваем сковороду...");
            await Task.Delay(5000);
            Console.WriteLine($"Разбиваем {howMany} яиц");
            Console.WriteLine("Жарим яица...");
            await Task.Delay(5000);
            Console.WriteLine("Накладываем яица на тарелку");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Наливаем кофе");
            return new Coffee();
        }
    }
}
