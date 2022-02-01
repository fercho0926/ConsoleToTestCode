using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.Basic
{
    public class List
    {
        //Create  the list
        public void createList() {

            List<double> list = new List<double>();
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
    }
}
