using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.DelegatesClass
{
    public class DelegatesDefinition
    {
        //Un delegado es basicamente definir un tipo de dato que me sirve como apuntador a diferentes metodos que conserven la misma
        //Estructura de tipo de dato y parametros. 
        //Se usa como variable o campo que puede apuntar a diferntes metodos con la misma estructura  con implementaciones distintas


        //1. debemos crear el tipo de dato DELEGATE
        public delegate string ObjetoDelegate(string Message);

        //2. luego de definir el tipo de dato, procedemos a crear los metodos o apuntadores que deben tener la misma estructura
        private string metodoLlamadoDesdeDelegate(string msj)
        {

            Console.WriteLine($"Este es el mensaje que manda el consumidor{msj}");
            return "Ya fue ejecuado el mensaje y nos devolvemos para el metodo consumidor";
        }

        //3. creamos el metodo que va a llamar a nuestro delegado, este puede tener una estructura dsitinta, porque solo va a usar el delegado
        //por ende ahunque el delegado sea tipo string, vamos a crear este metodo tipo void
        public void ImplementandoDelegates()
        {

            //Debemos instanciar el delegate , OJO que con el delegate se debe indicar el metodo
            ObjetoDelegate obj = metodoLlamadoDesdeDelegate;

            //con el objeto Instanciado, este funciona como apuntador y se puede empezar a utilizar
            var resultadoDelegate = obj("Invoncando el delegate");
            Console.WriteLine(resultadoDelegate);

            //Llamando otro metodo con diferente implementacion
            ObjetoDelegate obj2 = metodoDiferenteDelegate;
            string resultD = obj2("***** SEGUNDO DELEGATE ****** ");
            Console.WriteLine(resultD);
        }




        //---------------------------------------------------------------------------------------------------------
        //Luego de terminar con lo anterior vamos a probar las diferentes implemetaciones de delegates, 

        //4. creamos otro metodo con la misma estructura que haga algo diferente a imprimir

        public string metodoDiferenteDelegate(string msj)
        {
            var listNew = new List<int> { 1, 3, 6, 8, 4, 9, 33 };
            int mayor = listNew.OrderByDescending(d => d).First();
            return $"El numero mayor de la lista es {mayor} y el mensaje que mando fue {msj}";
        }
    }
}
