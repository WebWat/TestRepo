using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Temp<T>
    {
        public T Item { get; set; }

        public Temp(T item) => Item = item;

        public T GetItem()
        {
            return Item;
        }
    }

    class Program
    {
        static Temp<long> temp = new Temp<long>(0);

        static async Task Main(string[] args)
        {
            Console.WriteLine("Press something to add a new operation:");

            int x = 0;

            while (true)
            {
                Console.ReadKey();

                await Task.Run(() => Operation(ref x, (a, b) =>
                {
                    long result = a - b;

                    if (result > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"[+{result}]\n");
                    }
                    else if (result == 0)
                    {
                        Console.Write($"[+{result}]\n");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"[{result}]\n");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }));
            }
        }

        static void Operation(ref int num, Action<long, long> action)
        {
            if (num <= 100)
            {
                long totalMemory = GC.GetTotalMemory(false);

                Console.Write($" - ({num:d3}) - Memory: ");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{totalMemory}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" byte ");

                action(totalMemory, temp.Item);

                temp.Item = totalMemory;

                num++;
            }
            else
            {
                num = 0;

                GC.Collect();
                GC.WaitForPendingFinalizers();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" - GARBAGE COLLECTION\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
