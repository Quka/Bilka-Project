using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model.Interface;

namespace Stock_Management.Model
{
    public class ProductReturn : IProductReturn
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
	    public DateTime Date { get; set; }
	    public int Amount { get; set; }
	    public string Description { get; set; }

        public override string ToString()
        {
            return "Date [" + Date + "], Amount [" + Amount + "], Description [" + Description + "]";
        }
    }
}
