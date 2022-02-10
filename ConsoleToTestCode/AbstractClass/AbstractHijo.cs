using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.AbstractClass
{
    public class AbstractHijo : AbstractDef
    {
        public override void ImplementarMetodoAbstracto()
        {
            Console.WriteLine("metodo implementado desde el hijo");
        }


    }
}
