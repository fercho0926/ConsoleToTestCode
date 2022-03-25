using System;

namespace ExtencionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string demo = "THIS IS A DEMO";

            demo.PrintToConsole();

        }
    }

    public static class Extensions
    {
        public static void PrintToConsole(this string message)
        {
            Console.WriteLine(message);
        }

    }


}
