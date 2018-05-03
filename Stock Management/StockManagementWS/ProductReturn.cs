namespace StockManagementWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductReturn")]
    public partial class ProductReturn
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        public virtual Product Product { get; set; }
    }
}
