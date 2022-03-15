using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Generics.Entities
{
    public class Organization : EntityBase
    {
        public string? Name { get; set; }
        public string? City { get; set; }


        public override string ToString() => $"Id: {Id}, OrganizationName: {Name}, City : {City}";

    }
}
