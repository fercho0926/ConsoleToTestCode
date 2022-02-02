using ConsoleToTestCode.Basic;
using System;

namespace ConsoleToTestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            prueba("PRUEBA METODO STATICO");

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
                    basicList.InfoList();

                    break;
                case "3":
                    //List
                    var firstClass = new FirstClass("CLASE");

                    var highNumber = double.MinValue; 
                    for (int i = 0; i < 10; i++)
                    {
                        var rdm = new Random();
                        double randonNumber = rdm.Next(1, 100);

                        if (randonNumber> highNumber)
                        {
                            highNumber = randonNumber;
                        }


                        firstClass.AddDoubleList(randonNumber);
                    }
                    Console.WriteLine(firstClass.name);
                    Console.WriteLine($"The HighGest Number is{highNumber}");
                    firstClass.PrintList();
                  


                    break;
                default:
                    break;
            }
        }

         static void prueba(string msg) {

            Console.WriteLine(msg);

        }
    }
}
