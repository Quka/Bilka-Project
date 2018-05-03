using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Management.Handler
{
    interface _ProductHandler
    {
        public List<Product> FindProducts { get; set; }
    }
}
