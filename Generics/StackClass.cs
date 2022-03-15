using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class StackClass
    {
        public static void StackDoubles()
        {
            var stack = new Stack<double>();
            stack.Push(1.2);
            stack.Push(2.8);
            stack.Push(3.0);

            double sum = 0.0;

            while (stack.Count > 0)
            {
                double item = stack.Pop();
                Console.WriteLine($"Item {item}");
                sum += item;
            }
            Console.WriteLine($"Sum : {sum}");
        }

        public static  void StackStrings()
        {
            var stack = new Stack<string>();
            stack.Push("string 1");
            stack.Push("string 2");
            stack.Push("string 3");

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

        }

    }
}
