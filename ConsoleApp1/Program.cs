using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press something to add new task:");
            while (true)
            {
                Console.ReadKey();
                await Task.Run(() => Operation());
            }
        }

        static void Operation()
        {
            Console.WriteLine(" - Hello");
        }
    }
}
