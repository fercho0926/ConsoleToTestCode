using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.Struct
{
    struct InitialStruct
    {
        public string Name;
        public string Departament;

        public void struckMethod() {
            Console.WriteLine($"Struck Methods print the Name {Name} and Departament {Departament}");
        }
    }
}
