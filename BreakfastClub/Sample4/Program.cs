using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Common;

namespace Sample4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Coffee cup = PourCoffee();
            Console.WriteLine("Кофе готов");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("Яица готовы");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("Бекон готов");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("Тосты готовы");
                }
                breakfastTasks.Remove(finishedTask);
            }

            sw.Stop();
            Console.WriteLine($"Завтрак готов за {sw.Elapsed.Seconds} минут");
        }


        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Намазываем джем на тост");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Намазываем масло на тост");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
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
