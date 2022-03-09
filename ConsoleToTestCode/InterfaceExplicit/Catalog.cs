using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.InterfaceExplicit
{
    public class Catalog : ISaveable
    {
        void ISaveable.save()
        {
            Console.WriteLine("EXPLICIT IMPLEMENTATION");
        }
    }
}
