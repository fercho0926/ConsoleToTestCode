using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.SealedClass
{
     sealed class ClasePadreSealed
    {

        public void metodo() {
            Console.WriteLine("No permite heredar este metodo, porque la clase esta sellada");
        }
        
    }
}
