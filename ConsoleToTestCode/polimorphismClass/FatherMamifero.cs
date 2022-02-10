using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.polimorphismClass
{
    public class FatherMamifero
    {

        public string Name { get; set; }

        public void PensarconNew() {

            Console.WriteLine("Soy capaz de pensar con NEW");
        }


        // todas las subclases deben tener un metodo pensar que modifique el comprotamiento 
        public virtual void PensarConOverrideYVirtual() {
            Console.WriteLine("Soy capaz de pensar con NEW");

        }





    }
}
