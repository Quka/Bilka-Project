using System.Runtime.InteropServices;

namespace StockManagementWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int SupplierId { get; set; }

	    public int Amount { get; set; }

        [Required]
        [StringLength(200)]
        public string Status { get; set; }

        public DateTime Date { get; set; }

        public DateTime EstDelivery { get; set; }

        public byte Approved { get; set; }

        public virtual Product Product { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
