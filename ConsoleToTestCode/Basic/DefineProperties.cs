using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.Basic
{
    public class DefineProperties
    {
        readonly string readOnlyField = "readonly"; // is a fiel that i only can initialize in the contructor or set a value by default 
        public const string CONSTANTFIELD = "Constan Field it does´t change";

        public int publicproperty { get; set; }
        private int privateproperty { get; set; }

        public string LongDescription
        {
            get
            {
                return "value";
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    value = "value";
                }
            }
        }

        public int publicGetPrivateSet
        {
            get;
            private set;
        }

        

    }
}
