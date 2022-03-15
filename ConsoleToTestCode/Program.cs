using ConsoleToTestCode.Basic;
using ConsoleToTestCode.DelegatesClass;
using ConsoleToTestCode.Enum;
using ConsoleToTestCode.HeritanceClass;
using ConsoleToTestCode.InterfaceExplicit;
using ConsoleToTestCode.polimorphismClass;
using ConsoleToTestCode.Records;
using ConsoleToTestCode.Struct;
using Newtonsoft.Json;
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
                    //Class
                    var firstClass = new FirstClass("CLASE");

                    //Call Static values
                    var staticvalueWithoutInstanciate = FirstClass.staticValues;

                    var highNumber = double.MinValue;
                    for (int i = 0; i < 10; i++)
                    {
                        var rdm = new Random();
                        double randonNumber = rdm.Next(1, 100);

                        if (randonNumber > highNumber)
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

                case "10": //Polimorphism
                    var polim = new SonHuman();
                    polim.PensarConOverrideYVirtual();
                    break;

                case "11": //Interfaces
                    //POR IMPLEMENTAR
                    break;

                case "12": //Abstracts
                    //POR IMPLEMENTAR
                    break;

                case "13": //datetime
                    var datime = new DatetimeClass();

                    datime.DateTimesDef();
                    break;

                case "14": //Enum

                    InitialEnum value = InitialEnum.Manager;
                    Console.WriteLine(value);
                    break;
                case "15": //struct
                    InitialStruct struckNew;
                    struckNew.Name = "MIlton";
                    struckNew.Departament= "antioquia";
                    struckNew.struckMethod();
                 
                    break;

                case "16": //explicit Implementation : INTERFACE

                    Catalog catalog = new Catalog();
                    //catalog.save(); //is not here becasuse is explicit, we have to call the interface

                    //Way 1 to consume
                    ISaveable saveable = new Catalog();
                    saveable.save();

                    //Way 2 to consume
                    ((ISaveable)catalog).save();

                    //DO NOT USE Var, because dont call the Interface
                    var implicitCatalog = new Catalog();
                    //implicitCatalog.save();


                    break;
                case "17":
                    //RECORS

                    var records = new Course();
                    records.Name= "Course Repos";
                    records.Author = "Ferney";


                    var CallTheRecors = new RecordDefinition(
                        "NameRecore",
                        "Fer"
                        );

                    break;

                default:
                    break;
            }
        }

        static void prueba(string msg)
        {

            Console.WriteLine(msg);

        }

        static void testPackages()
        {

            //lets implment a class from a packagege implemented

        }
    }
}
