using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Dictionary
    {
        //How to create a Dictionary

        public void CreateDictionary() {

            var dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "message");
        }
    }
}
