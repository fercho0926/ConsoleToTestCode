using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.polimorphismClass
{
    public class SonHuman : FatherMamifero
    {
        //humano al hererar de mamifero, hereda los metodos, pero el metodo pensar ya lo tiene el padre
        // el metodo de la clase hijo invalida a la clase padre y se imprime lo que tiene el hijo
        //Siempre y cuando los parametros sean los mismos, porque si cambi

      

        new public void PensarconNew() {

            Console.WriteLine("el mismo nombre del metodo del padre");
        }

        public override void PensarConOverrideYVirtual()
        {
            Console.WriteLine("HIJO, con override al padre");

        }
         
    }
}
