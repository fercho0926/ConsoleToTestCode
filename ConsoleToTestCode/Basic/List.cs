using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.Basic
{
    public class List
    {
        List<double> list;

        public List()
        {
            list = new List<double>();
        }

        //Create  the list
        public void createList()
        {


            list.Add(10.2);
            list.Add(20);
            list.Add(5.2);

            //Inicializar la Lista al principio
            var list2 = new List<double>() { 10.5, 5, 6, 9, 5, 10.2 };

            // print the list
            Console.WriteLine("print List1");
            foreach (var item in list)
            {
                Console.WriteLine(item);

            }
        }

        public void InfoList()
        {
            Console.WriteLine($"Max number on the  list {list.Max()}");
            Console.WriteLine($"Min number on the  list {list.Min()}");
            Console.WriteLine($"Amount {list.Count}");
            Console.WriteLine($"Average {list.Average()}");
            Console.WriteLine($"Id the list contains number 3 {list.Contains(3)}");
            Console.WriteLine($"Id the list contains number 3 {list.OrderByDescending(x => x).ToList()}");

        }
    }
}
