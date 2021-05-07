using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Common;

namespace Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Coffee cup = PourCoffee();
            Console.WriteLine("Кофе готов");

            Egg eggs = FryEggs(2);
            Console.WriteLine("Яица готовы");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("Бекон готов");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("Тосты готовы");

            sw.Stop();
            Console.WriteLine($"Завтрак готов за {sw.Elapsed.Seconds} минут");
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Намазываем джем на тост");

        private static void  ApplyButter(Toast toast) =>
            Console.WriteLine("Намазываем масло на тост");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Помещаем хлеб в тостер");
            }
            Console.WriteLine("Включаем тостер...");
            Task.Delay(5000).Wait();
            Console.WriteLine("Вынимаем тосты из тостера");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"Кладем {slices} кусосков бекона на сковороду");
            Console.WriteLine($"Жарим {slices} кусосков бекона...");
            Task.Delay(5000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Переворачиваем кусок бекона");
                Task.Delay(2000).Wait();
            }

            Console.WriteLine("Накладываем бекон на тарелку");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Разогреваем сковороду...");
            Task.Delay(5000).Wait();
            Console.WriteLine($"Разбиваем {howMany} яиц");
            Console.WriteLine("Жарим яица...");
            Task.Delay(5000).Wait();
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
