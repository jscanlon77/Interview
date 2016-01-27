using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static bool workDone;

        public static void Foo(int x = 0, int y = 1, string s = "abc")
        {
            Console.WriteLine(x + y + s);
        }
        public static object locker = new object();
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder("john");
            Console.WriteLine(text);
        }

        
         
    }
}
