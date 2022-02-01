using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.Basic
{
    public class Arrays
    {
        public Arrays()
        {

        }

        public void arrayInfo() {
            Random random = new Random();


            //Declare the Array
            var numbers = new double[10];

            //Fill the array
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
