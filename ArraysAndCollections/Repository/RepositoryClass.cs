using ArraysAndCollections.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndCollections.Repository
{
    public class RepositoryClass
    {
        private readonly BaseClassDef[] _allClasses;

        public RepositoryClass()
        {
            _allClasses = new BaseClassDef[] {
             new BaseClassDef(1, "Milton", "Vasquez", new string[] { "Address1", "Address2", "Address3" }),
             new BaseClassDef(2, "vero", "vargas", new string[] { "Address4", "Address5", "Address6" }),
             new BaseClassDef(3, "mama", "herrera", new string[] { "Address4", "Address5", "Address6" }),
             new BaseClassDef(4, "mile", "vas", new string[] { "Address4", "Address5", "Address6" }) };
        }

        public BaseClassDef[] findClassWithName( string name) {

            return Array.FindAll(_allClasses, x=> x.Name  == name);
        }

        public BaseClassDef[] findNamesBetween(string name1, string name2) {

            return Array.FindAll(_allClasses, x => x.Name == name1 && x.Name == name2);
        }

    }

}

