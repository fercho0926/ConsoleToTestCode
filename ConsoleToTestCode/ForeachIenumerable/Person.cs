using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.ForeachIenumerable
{
    public class Person
    {
        private int _id;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public Person(int Id, string Name, string LastName)
        {
            this.Id = Id;
            this.Name = Name;
            this.Lastname = Lastname;
        }


    }
}
