using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.HeritanceClass
{
    public class ChildClass : FatherClass
    {

        public string games { get; set; }
        public ChildClass()
        {
            Id = 3;
            Name = "Child";
            LastName = "heritance from father";
            Job = " the child has no job";
            games = "any kind of game";
        }
    }
}
