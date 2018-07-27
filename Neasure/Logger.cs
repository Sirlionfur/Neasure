using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neasure
{
    class Logger
    {
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
    }
}
