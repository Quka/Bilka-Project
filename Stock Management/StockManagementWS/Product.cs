namespace StockManagementWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order = new HashSet<Order>();
            ProductReturn = new HashSet<ProductReturn>();
        }

        public int Id { get; set; }

        public int SupplierId { get; set; }

        public int ItemNr { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        public int MinStock { get; set; }

        public int RestockAmount { get; set; }

        public DateTime RestockPeriod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductReturn> ProductReturn { get; set; }
    }
}
