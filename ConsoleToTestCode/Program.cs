using ConsoleToTestCode.Basic;
using System;

namespace ConsoleToTestCode
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Number");
            var num = Console.ReadLine().ToString();

            switch (num)
            {
                case "1":
                    //Arrays
                    var array = new Arrays();
                    array.BasicArray();
                    break;

                case "2":
                    //List
                    var basicList = new List();
                    basicList.createList();
                    break;
                default:
                    break;
            }
        }
    }
}
