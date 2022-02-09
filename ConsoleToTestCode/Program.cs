using ConsoleToTestCode.Basic;
using ConsoleToTestCode.DelegatesClass;
using ConsoleToTestCode.HeritanceClass;
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

                case "4":
                    var ReferenciesAndValueTypes = new ReferenciesAndValueTypes();
                    //ReferenciesAndValueTypes.ObjetosDiferenteReferencia();
                    //ReferenciesAndValueTypes.ObjetosMismaReferencia();
                    //ReferenciesAndValueTypes.PasarObjetosPorReferencia();
                      //ReferenciesAndValueTypes.PasarValueTypesSinReferencia();
                    ReferenciesAndValueTypes.PasarValueTypesConReferencia();
                    break;

                case "5":
                    var exceptions = new ExceptionClass();
                    // exceptions.exceptionCrashMessage("test");
                    exceptions.tryCatch();
                    break;

                case "6": //Overload
                    var Overload = new OverloadMethods();
                    Overload.overloadMethod();
                    Overload.overloadMethod("HI");
                    break;
                case "7": //delegate simple
                    var delegateDef = new DelegatesDefinition();
                    delegateDef.ImplementandoDelegates();
                    break;
                case "8": //delegate Multiple
                    var delegateMultiple = new DelegatesMulticast();
                    delegateMultiple.LlamandoDelegadoMultiple();
                    break;

                case "9": //Heritance
                    //var grandpa = new GrandFatherClass();
                    //grandpa.printvalues();

                    //var father = new FatherClass();
                    //father.printvalues();

                    var child = new ChildClass();
                    child.printvalues();
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
