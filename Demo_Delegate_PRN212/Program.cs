using System;

namespace Demo_Delegate_PRN212
{ 
        internal class Program
        {
        //Insstantiating Delegates
        static int Add(int a, int b) => a + b;
        static int Sub(int a, int b) => a - b;
        static void PrintMessage(string message) => Console.WriteLine(message);

        //Passing Delegate as a Parameter
        static void InvokeDelegate(MessageDelegate dele, string msg) => dele(msg);

        //Anonymous Method
        public delegate void AnonymousDelegate(int value);

        //Generic Delegate Types 
        static int Sum(int x, int y) => x + y;
        static void Print(string msg) => Console.WriteLine(msg.ToUpper());

        //Lab 4
        static Operation<double> add = (a, b) => a + b;
        static Operation<double> subtract = (a, b) => a - b;
        static Operation<double> multiply = (a, b) => a * b;
        static Operation<double> divide = (a, b) => b != 0 ? a / b : throw new DivideByZeroException();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("==========MENU==========");
                Console.WriteLine("1. Demo Instantiating Delegates");
                Console.WriteLine("2. Demo Passing Delegate as a Parameter");
                Console.WriteLine("3. Demo Multicast Delegate");
                Console.WriteLine("4. Demo Anonymous Method");
                Console.WriteLine("5. Demo Generic Delegate Types");
                Console.WriteLine("6. Lab 4");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        int n1 = 25;
                        int n2 = 15;
                        int result;
                        MessageDelegate m = PrintMessage;
                        MyDelegate obj1 = new MyDelegate(Add);
                        result = obj1(n1, n2);
                        Console.WriteLine($"{n1} + {n2} = {result}");
                        m("Sum " + obj1(n1, n2));
                        MyDelegate obj2 = Sub;
                        result = obj2.Invoke(n1, n2);
                        Console.WriteLine($"{n1} - {n2} = {result}");
                        Console.ReadLine();
                        break;
                    case 2:
                        string msg = "Passing Delegate As A Parameter";
                        InvokeDelegate(MyClass.Print, msg);
                        InvokeDelegate(MyClass.Show, msg);
                        Console.ReadLine();
                        break;
                    case 3:
                        string message = "Multicast Delegate";
                        MessageDelegate dele01 = MyClass.Print;
                        MessageDelegate dele02 = MyClass.Show;
                        Console.WriteLine("***Combines dele01 + dele02***");
                        MessageDelegate dele = dele01 + dele02;
                        dele(message);
                        Console.WriteLine("\n***Combines dele01 + dele02 + dele03***");
                        MessageDelegate dele03 = MyClass.Display;
                        dele += dele03;
                        dele(message);
                        Console.WriteLine("\n***Remove dele02***");
                        dele -= dele02;
                        dele("Hello World !");
                        Console.ReadLine();
                        break;
                    case 4:
                        AnonymousDelegate printValue = delegate (int value)
                        {
                            Console.WriteLine("Inside Anonymous Method. Value: {0} ",value);
                        };
                        printValue += delegate (int value)
                        {
                            Console.WriteLine("This is Anonymous Method.");
                        };
                        printValue(100);
                        Console.ReadLine();
                        break;
                    case 5:
                        int x = 15, y = 25, s;
                        string strResult;
                        Func<int, int, int> sumFunc = Sum;
                        s = sumFunc(x, y);
                        strResult = $"{x} + {y} = {s}";
                        Console.WriteLine("\n***Invoke Print method by Action delegate***");
                        Action<string> printAction = Print;
                        printAction(strResult);
                        Console.ReadLine();
                        break;
                    case 6:
                        try
                        {
                            Console.WriteLine("=====Calculate=====");
                            Console.Write("Enter number 1: ");
                            double num1 = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter number 2: ");
                            double num2 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine($"\n***Addition: {num1} + {num2} = {add(num1, num2)}");
                            Console.WriteLine($"***Subtraction: {num1} - {num2} = {subtract(num1, num2)}");
                            Console.WriteLine($"***Multiplication: {num1} * {num2} = {multiply(num1, num2)}");
                            Console.WriteLine($"***Division: {num1} / {num2} = {divide(num1, num2)}");
                            Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
