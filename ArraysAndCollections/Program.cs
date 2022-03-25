
using ArraysAndCollections.BaseClass;
using ArraysAndCollections.Repository;
using System;
using System.Collections.Generic;

namespace ArraysAndCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayDeclaration();
            //ListDeclaration();
            //DictionaryDeclaration();
            HashSetDeclaration();




        }

        private static void HashSetDeclaration()
        {
            RepositoryClass repository = new RepositoryClass();

            Console.WriteLine("write the name u want to search");
            string name1 = Console.ReadLine();
            BaseClassDef[] arrayClasses = repository.findClassWithName(name1);

            Console.WriteLine("write the name u want to search 2");
            string name2 = Console.ReadLine();
            //easy way without hashset
            BaseClassDef[] arrayClasses2 = repository.findNamesBetween(name1, name2);

            //hashset is the one who calculate the intersection of 2 sets
            BaseClassDef[] set1 = repository.findClassWithName(name1);
            BaseClassDef[] set2 = repository.findClassWithName(name2);

            HashSet<BaseClassDef> intersection = new HashSet<BaseClassDef>(set1);
            intersection.IntersectWith(set2);
            if (intersection.Count > 0)
            {
                foreach (BaseClassDef item in intersection)
                {
                    Console.WriteLine($"Items in both sets {item}");

                }

            }



        }

        private static void DictionaryDeclaration()
        {

            BaseClassDef Class1 = new BaseClassDef(1, "Milton", "Vasquez", new string[] { "Address1", "Address2", "Address3" });
            BaseClassDef Class2 = new BaseClassDef(2, "vero", "vargas", new string[] { "Address4", "Address5", "Address6" });
            BaseClassDef Class3 = new BaseClassDef(3, "mama", "herrera", new string[] { "Address4", "Address5", "Address6" });
            BaseClassDef Class4 = new BaseClassDef(4, "mile", "vas", new string[] { "Address4", "Address5", "Address6" });


            //-- WAY 1 To create a Dictionary
            var DictionaryClass = new Dictionary<int, BaseClassDef>();
            DictionaryClass.Add(1, Class1);
            DictionaryClass.Add(2, Class2);
            DictionaryClass.Add(3, Class3);
            DictionaryClass.Add(4, Class4);

            //way 2 to create a Dictionary
            var DictionaryClass2 = new Dictionary<int, BaseClassDef>
            {
                { 1, Class1 },
                { 2, Class2 },
                { 3, Class3 },
                { 4, Class4 }
            };

            //tryAngGEtValue
            bool success = DictionaryClass.TryGetValue(1, out BaseClassDef answer);
            Console.WriteLine(answer);

            //Constains Key
            bool successContainsKey = DictionaryClass.ContainsKey(1); //number

            //SortedDictionary
            var sortedDictionaryClass = new SortedDictionary<int, BaseClassDef>
            {
                { 1, Class1 },
                { 2, Class2 },
                { 3, Class3 },
                { 4, Class4 }
            };

            //print all the dictionary
            foreach (BaseClassDef item in sortedDictionaryClass.Values)
            {
                Console.WriteLine(item);
            }






        }

        private static void ListDeclaration()
        {
            List<BaseClassDef> result = new List<BaseClassDef>();
            result.Add(new BaseClassDef(1, "nameLisT", "lastnameList", new string[] { "array 1", "array2" }));
            result.Add(new BaseClassDef(2, "nameLisT2", "lastnameList2", new string[] { "array 3", "array4" }));

            Console.WriteLine($"The amount of element on thelist is {result.Count}");

            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.Name} ");

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
