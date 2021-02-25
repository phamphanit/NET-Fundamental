using System;

namespace TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var testClass = new ImplementationClass();
            try
            {
                testClass.Method2();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    public class ImplementationClass
    {
        public void Method1()
        {
            Console.WriteLine("Method 1 starting...");
            throw new Exception("Fail on Method 1 Exeption");

        }
        public void Method2()
        {
            Console.WriteLine("Method 2 starting...");
            try
            {
                Method1();
            }
            catch(Exception e)
            {
                Console.WriteLine("throw from method 2");
                throw new Exception(e.Message);
            }

        }
    }
}
