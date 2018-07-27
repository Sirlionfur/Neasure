using System;
using System.Runtime.InteropServices;

namespace Neasure
{
    class Logger
    {
        /* Currently Broken, Do not Use
    
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Logger()
        {
            AllocConsole();
        }

        public void Log(string msg)
        {
            Console.WriteLine("[LOG] " + msg);
        }

        public void LogWarning(string msg)
        {
            Console.WriteLine("[WARNING] " + msg);
        }

        public void LogError(string msg)
        {
            Console.WriteLine("[ERROR] " + msg);
        }

    */
    }
}
