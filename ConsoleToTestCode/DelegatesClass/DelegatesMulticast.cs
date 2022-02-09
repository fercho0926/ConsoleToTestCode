using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.DelegatesClass
{
    public class DelegatesMulticast
    {
        //Cabe resaltar que puedo tener multiples invocaciones con los delegados, vamos a verlo
        // se hace porque puedo tener el mismo apuntador apuntando a varios metodos para que ejecuten las tareas con una solo llamado

        //1. declarar el delegado
        public delegate string DelegadoMultiple (string messaje);

        //2. crear los metodos con diferentes funcionalidades
        private string ConvertirMayuscula(string msj) {
            string mssj = msj.ToUpper();
            Console.WriteLine($"Entro a Convertir el texto a mayuscula{mssj}");
            return mssj;
        }

        private string ConvertirMinuscula(string msj)
        {
            string mssj = msj.ToLower();
            Console.WriteLine($"Entro a Convertir el texto a minuscula{mssj}");
            return mssj;
        }


        //3 realizar el llamado al delegate
        public void LlamandoDelegadoMultiple() {

            // Instanciar el objeto
            DelegadoMultiple multiple =  ConvertirMinuscula; // con esta linea le decimos al delegado que vamos a usar el metodo ConvertirMinuscula
            multiple += ConvertirMayuscula; // con esta adicion, le decimos que tambien vamos a usar el metodo ConvertirMayuscula, AMBOS A LA MISMA VEZ

            Console.WriteLine("**Vamos a Imprimir el resultado del llamado doble, NOTESE que se llama 1 vez y apunta a los 2 metodos asi que se ejecuta en amos lados");

            Console.WriteLine(multiple("MenSAjE CONVErTido"));



        }
    }
}
