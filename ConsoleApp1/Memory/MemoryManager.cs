using System;
using System.Diagnostics;

namespace ConsoleApp1.Memory
{
    public class MemoryManager
    {
        private readonly NativeMethods NativeMethods;

        public MemoryManager()
        {
            NativeMethods = new NativeMethods();
        }

        public void GetProcessMemory(int pid)
        {
            try
            {
                using Process p = Process.GetProcessById(pid);

                Console.Write($"Process memory: ");
                ChangeColor($"{(double)p.PeakPagedMemorySize64:### ### ###}", ConsoleColor.Green);
                Console.Write(" b = ");
                ChangeColor($"{(double)p.PeakPagedMemorySize64 / 1048576:f1}", ConsoleColor.Green);
                Console.WriteLine(" Mb");
            }
            catch
            {
                Console.WriteLine();
            }
        }

        public void GetRam()
        {
            ChangeColor($"[Total: {(double)NativeMethods.GetUllTotalPhys() / 1073741824:f1} Gb " +
                $"Free: {(double)NativeMethods.GetAvailPhys() / 1073741824:f1} Gb " +
                $"Busy: {(double)(NativeMethods.GetUllTotalPhys() - NativeMethods.GetAvailPhys()) / 1073741824:f1} Gb]\n", ConsoleColor.Green);
        }

        private void ChangeColor(string message, ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
