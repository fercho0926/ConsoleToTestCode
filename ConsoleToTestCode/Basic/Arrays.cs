using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.Basic
{
    public class Arrays
    {

        public void BasicArray() {
            Random random = new Random();


            //Declare the Array and fill the array
            var numbers = new double[5] {10,25,36,31,58};
           // var numbers = new double[] {10,25,36,31,58};

            //Fill the array option1
            for (int i = 0; i < numbers.Length; i++)
            {
                double randomNumer = random.Next(0, 20);
                numbers[i] = randomNumer;
            }

            //Read the Array
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

        }


      


    }


}
