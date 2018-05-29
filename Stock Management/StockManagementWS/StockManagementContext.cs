namespace StockManagementWS
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class StockManagementContext : DbContext
	{
		public StockManagementContext()
			: base("name=StockManagementContext")
		{
			base.Configuration.ProxyCreationEnabled = false;
		}

		public virtual DbSet<Employee> Employee { get; set; }
		public virtual DbSet<Order> Order { get; set; }
		public virtual DbSet<Product> Product { get; set; }
		public virtual DbSet<ProductReturn> ProductReturn { get; set; }
		public virtual DbSet<Supplier> Supplier { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.Property(e => e.SalNo)
				.IsUnicode(false);

			modelBuilder.Entity<Employee>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Employee>()
				.Property(e => e.Password)
				.IsUnicode(false);

			modelBuilder.Entity<Order>()
				.Property(e => e.Status)
				.IsUnicode(false);

			modelBuilder.Entity<Product>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Product>()
				.Property(e => e.Price)
				.HasPrecision(8, 2);

			modelBuilder.Entity<Product>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Order)
				.WithRequired(e => e.Product)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.ProductReturn)
				.WithRequired(e => e.Product)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ProductReturn>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.Property(e => e.Address)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.Property(e => e.Phone)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.HasMany(e => e.Order)
				.WithRequired(e => e.Supplier)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Supplier>()
				.HasMany(e => e.Product)
				.WithRequired(e => e.Supplier)
				.WillCascadeOnDelete(false);
		}
	}
}
