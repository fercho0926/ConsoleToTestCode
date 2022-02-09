using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.HeritanceClass
{
    public class FatherClass : GrandFatherClass
    {
        public string Job { get; set; }

        public FatherClass()
        {
            Id = 2;
            Name = "Father";
            LastName = "Heritance from father";
        }

        public void HasAHouse() {

            Console.WriteLine("HAs a House");
        }

    }
}
