using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Generics.Entities
{
    public class Manager : Employee
    {
        public override string ToString() => base.ToString() + "(Manager)";

    }
}
