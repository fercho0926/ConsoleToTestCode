using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.HeritanceClass
{
    public class GrandFatherClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


        public GrandFatherClass()
        {
            Id = 1;
            Name = "grandPa"; 
            LastName = "lastnameGrandpa";

        }

        public void HasACar() {
            Console.WriteLine("WE HAVE A CAR");
        }

        public void printvalues() {

            Console.WriteLine($"The {Id}, with Name {Name}, and Lastname {LastName} is here");
        }


    }
}
