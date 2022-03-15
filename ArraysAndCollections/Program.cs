
using ArraysAndCollections.BaseClass;
using System;
using System.Collections.Generic;

namespace ArraysAndCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayDeclaration();
            ListDeclaration();

        }

        private static void ListDeclaration()
        {
            List<BaseClassDef> result = new List<BaseClassDef>();
            result.Add(new BaseClassDef(1, "nameLisT", "lastnameList", new string[]{ "array 1","array2" }));
            result.Add(new BaseClassDef(2, "nameLisT2", "lastnameList2", new string[]{ "array 3","array4" }));

            Console.WriteLine($"The amount of element on thelist is {result.Count}");

            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.Name} " );

            }

            //Delete 
            result.RemoveAt(1);
            
      
        }

        private static void ArrayDeclaration()
        {

            BaseClassDef Class1 = new BaseClassDef(1, "Milton", "Vasquez", new string[] { "Address1", "Address2", "Address3" });
            BaseClassDef Class2 = new BaseClassDef(1, "vero", "vargas", new string[] { "Address4", "Address5", "Address6" });

            BaseClassDef[] classesInArray = {
                Class1,
                Class2,
                new BaseClassDef(3, "joel", "Espinosa", new string[] {"Address7" , "Address2", "Address9" }),
                new BaseClassDef(4, "nuevo objeto", "joel", new string[] {"Address5" , "Address1", "Address3" })
        };
            //-- PRINT
            foreach (var item in classesInArray)
            {
                Console.WriteLine(item);

            }

            //-- Print 
            string ItemToFind = "joel";
            FindArray(classesInArray, ItemToFind);
            BaseClassDef[] FindAll = FindAllArrays(classesInArray, ItemToFind);
            if (FindAll.Length > 0)
            {
                Console.WriteLine("Have Found the Item");
            }

            //--Resize the array-- is not the best option because copy the array and create a new one
            Array.Resize(ref classesInArray, 6);



        }

        private static BaseClassDef[] FindAllArrays(BaseClassDef[] classesInArray, string itemToFind)
        {
            return Array.FindAll(classesInArray,
               item => item.Name == itemToFind);
        }

        private static BaseClassDef FindArray(BaseClassDef[] classesInArray, string ItemToFind)
        {
            return Array.Find(classesInArray,
                item => item.Name == ItemToFind || item.Lastname == ItemToFind);
        }
    }
}
