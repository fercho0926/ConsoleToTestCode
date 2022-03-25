using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ.EntityClasses
{
    public partial class SaleProducts
    {
        public int SalesOrderID { get; set; }
        public List<Product> Products { get; set; }
    }
}
