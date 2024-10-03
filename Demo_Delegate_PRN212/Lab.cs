using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Delegate_PRN212
{
    public delegate int MyDelegate(int a, int b);
    public delegate void MessageDelegate(string message);
    class MyClass
    {
        public static void Print(string message) =>
            Console.WriteLine($"{message.ToUpper()}");
        public static void Show(string message) =>
            Console.WriteLine($"{message.ToLower()}");
        public static void Display(string message) =>
            Console.WriteLine($"{message}");
    }

    public delegate T Operation<T>(T a, T b);
}
