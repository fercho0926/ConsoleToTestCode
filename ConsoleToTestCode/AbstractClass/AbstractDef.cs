using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.AbstractClass
{
    public abstract class AbstractDef
    {

        public void metodoSinAbstraccion() {
            Console.WriteLine("Este metodo se hereda pero no se obliga a utilizar");
        }

        public abstract void ImplementarMetodoAbstracto();

        
    }
}
