using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.AbstractClass
{
    public class AbstractHijo : AbstractDef, IInterfaz1
    {
        public override void ImplementarMetodoAbstracto()
        {
            Console.WriteLine("metodo implementado desde el hijo");
        }

        public int revisar()
        {
            throw new NotImplementedException();
        }
    }
}
