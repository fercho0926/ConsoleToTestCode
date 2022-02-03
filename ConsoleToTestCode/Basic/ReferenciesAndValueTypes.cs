using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.Basic
{
    public class ReferenciesAndValueTypes
    {

        public void PasarValueTypesConReferencia()
        {

            int x = 5;
            Console.WriteLine(x);
            Console.WriteLine($"----antes del metodo{x}");
            MetodoQueRecibeValueTypesRef(ref x);
            Console.WriteLine($"----despues del metodo{x}");
        }

        private void MetodoQueRecibeValueTypesRef(ref int x)
        {
            x = 10;
            Console.WriteLine(x);
            Console.WriteLine($"----antes del metodo{x}");
            MetodoQueRecibeValueTypes(x);
            Console.WriteLine($"----despues del metodo{x}");
        }

        public void PasarValueTypesSinReferencia() {

            int x = 5;
            Console.WriteLine(x);
            Console.WriteLine($"----antes del metodo{x}");
            MetodoQueRecibeValueTypes(x);
            Console.WriteLine($"----despues del metodo{x}");
        }

        private void MetodoQueRecibeValueTypes(int x)
        {
            x = 10;
            Console.WriteLine($"valor en el metodo{x}");
        }

        public void ObjetosDiferenteReferencia()
        {

            //Instanciar 2 objetos e imprimir el resultado
            var obj1 = new pruebaObjetos
            {
                Id = 1,
                Name = "Objeto 1"
            };

            var obj2 = new pruebaObjetos
            {
                Id = 2,
                Name = "Objeto 2"
            };

            Console.WriteLine($"Objeto 1: {obj1.Id} {obj1.Name}");
            Console.WriteLine($"Objeto 2: {obj2.Id} {obj2.Name}");
        }


        public void ObjetosMismaReferencia()
        {

            //Instanciar 2 objetos e imprimir el resultado
            var obj1 = new pruebaObjetos
            {
                Id = 1,
                Name = "Objeto 1"
            };

            var obj2 = new pruebaObjetos
            {
                Id = 2,
                Name = "Objeto 2"
            };
            Console.WriteLine("-------------ANTES DE ASIGNAR EL OBJ1 AL OBJ2-----------");

            Console.WriteLine($"Objeto 1: {obj1.Id} {obj1.Name}");
            Console.WriteLine($"Objeto 2: {obj2.Id} {obj2.Name}");

            //al asignar el objeto 1 al 2 se pasa la referencia y queda con lo mismo
            obj2 = obj1;


            Console.WriteLine("-------------ANTES DE CAMBIAR EL VALOR DEL OBJ 1-----------");

            Console.WriteLine($"Objeto 1: {obj1.Id} {obj1.Name}");
            Console.WriteLine($"Objeto 2: {obj2.Id} {obj2.Name}");


            Console.WriteLine("-------------DESPUES DE CAMBIAR EL VALOR DEL OBJ 1-----------");

            obj1.Name = "NUEVO NOMBRE OBJ 1";
            obj2.Name = "NUEVO NOMBRE OBJ 2"; 
            Console.WriteLine($"Objeto 1: {obj1.Id} {obj1.Name}");
            Console.WriteLine($"Objeto 2: {obj2.Id} {obj2.Name}");

            // A tener en cuento que imprime el nombre del obj porque ya no son 2 objetos diferetes,
            // comparten la referencia y toma el ultimo valor que se le mande
        }


        public void PasarObjetosPorReferencia() {
            var obj1 = new pruebaObjetos { Id = 1, Name = "obj1" };
            Console.WriteLine("-------------ANTES DE IR AL METODO-----------");
            Console.WriteLine($"Objeto 1: {obj1.Id} {obj1.Name}");
            MetodoQueRecibeObjetosPorReferencia(ref obj1);

            Console.WriteLine("----salio al metodo");
            Console.WriteLine($"Objeto 1: {obj1.Id} {obj1.Name}");
        }

        private void MetodoQueRecibeObjetosPorReferencia(ref pruebaObjetos obj1)
        {
            Console.WriteLine("----Entro al metodo");
            Console.WriteLine($"Objeto 1: {obj1.Id} {obj1.Name}");

            Console.WriteLine("----se modifica nombre por referencia");
            obj1.Name = "MODIFICADO DENTRO DEL METODO";
            Console.WriteLine($"Objeto 1: {obj1.Id} {obj1.Name}");
        }



    }


    public class pruebaObjetos
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }


}
