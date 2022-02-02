using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.Basic
{
    public class FirstClass
    {
        public string name { get; set; }
        //I can declare a field outside any method to be used by all Methods In the class
        List<double> doubleList;
        public FirstClass(string name)
        {
            this.name = name;
            doubleList = new List<double>();
        }
       

        public void AddDoubleList(double doubleNumber) {
            doubleList.Add(doubleNumber);
        }



        public void PrintList() {

            foreach (var item in doubleList)
            {
                Console.WriteLine(item);

            }
        }

    }
}
