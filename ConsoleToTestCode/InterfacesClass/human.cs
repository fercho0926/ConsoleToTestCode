using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.InterfacesClass
{
    public class human : mamifero, IInterfaz1, IInterfaz2
    {
     

        //Se implemento la interfaz Inicial
        public int numeroPatas()
        {
            var humano = 2;
            return humano;
        }

        public string respirar()
        {
            return ("soy capaz de respirar");
        }

        // este metodo esta en ambas interfaces, debemos solucionar la ambiguedad
        //1. debemos eliminar el modificador de acceso, SE ELIMINO EL TIPO DE DATO PUBLIC (se elimina para que no sea accesible desde afuera de la clase )
        //2. antes de llamar el motodo se debe indicar la Interfaz
         int IInterfaz1.Ambiguedad2Interfaces()
        {
            throw new NotImplementedException();
        }


        // se implementa el metodo de la segunda Interfaz
        int IInterfaz2.Ambiguedad2Interfaces()
        {
            throw new NotImplementedException();
        }
    }
}
