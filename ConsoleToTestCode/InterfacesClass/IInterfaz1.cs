using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.InterfacesClass
{
    public interface IInterfaz1
    {
        //Definiciones de los metodos a implementar 

        //Esta interfaz debe ser implementada por los mamiferos que tengan patas, y no debe ser implmentada para ballena
         int numeroPatas();


        //Solucion a ambiguedad de 2 interfaces
        int Ambiguedad2Interfaces();

    }
}
