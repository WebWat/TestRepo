using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            for (int i = 0; i <= 10; i++)
            {
                await Task.Run(() => Console.WriteLine($"Hello{i}!"));
                await Task.Delay(200);
            }
            Console.WriteLine("The End");
            Console.ReadKey();
        }
    }
}
