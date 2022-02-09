using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.Basic
{
    public class OverloadMethods
    {

        public int publicproperty { get; set; }
        private int privatecproperty { get; set; }


        public void overloadMethod() {
            Console.WriteLine("method to overload");
        }
        public void overloadMethod(string message)
        {
            Console.WriteLine($"method to overload with message{message}");
        }


    }
}
