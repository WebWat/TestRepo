using ConsoleApp1.Memory;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static MemoryManager MemoryManager = new MemoryManager();

        static void Main()
        {
            TimerCallback timerCallback = new TimerCallback(Operation);
            Timer timer = new Timer(timerCallback, null, 0, 60000);      

            Console.ReadKey();
        }
        
        static void Operation(object obj)
        {
            Console.Clear();
            GetAssemblyName();
            MemoryManager.GetRam();
            foreach (Process process in Process.GetProcesses())
            {
                Console.Write($"[ID: {process.Id,-5} Name: ");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{process.ProcessName,-40}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("] ");

                MemoryManager.GetProcessMemory(process.Id);
            }
        }

        static void GetAssemblyName()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine($"[Assembly name: {assembly.FullName.Split(',')[0]}]");
        }
    }
}
