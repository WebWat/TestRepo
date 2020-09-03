using System;

namespace ConsoleApp1.Memory
{
    public class NativeMethods
    {
        private MEMORYSTATUSEX msex;

        public ulong GetAvailPhys()
        {
            msex = new MEMORYSTATUSEX();

            if (Kernel32.GlobalMemoryStatusEx(msex))
            {
                return msex.ullAvailPhys;
            }
            else
                throw new Exception();
        }

        public ulong GetUllTotalPhys()
        {
            msex = new MEMORYSTATUSEX();

            if (Kernel32.GlobalMemoryStatusEx(msex))
            {
                return msex.ullTotalPhys;
            }
            else
                throw new Exception();
        }

        public void GetMemory()
        {
            msex = new MEMORYSTATUSEX();

            if (Kernel32.GlobalMemoryStatusEx(msex))
            {
                Console.WriteLine("{0} {1}", nameof(msex.dwLength), msex.dwLength);
                Console.WriteLine("{0} {1}", nameof(msex.dwMemoryLoad), msex.dwMemoryLoad);
                Console.WriteLine("{0} {1}", nameof(msex.ullAvailExtendedVirtual), msex.ullAvailExtendedVirtual);
                Console.WriteLine("{0} {1}", nameof(msex.ullAvailPageFile), msex.ullAvailPageFile);
                Console.WriteLine("{0} {1}", nameof(msex.ullAvailPhys), msex.ullAvailPhys);
                Console.WriteLine("{0} {1}", nameof(msex.ullAvailVirtual), msex.ullAvailVirtual);
                Console.WriteLine("{0} {1}", nameof(msex.ullTotalPageFile), msex.ullTotalPageFile);
                Console.WriteLine("{0} {1}", nameof(msex.ullTotalPhys), msex.ullTotalPhys);
                Console.WriteLine("{0} {1}", nameof(msex.ullTotalVirtual), msex.ullTotalVirtual);
            }
            else
                throw new Exception("Unable to initalize the GlobalMemoryStatusEx API");

        }
    }
}
