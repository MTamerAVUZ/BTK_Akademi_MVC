using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class RepositoryContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }

		public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>()
			.HasData(
					new Product() { ProductId = 1, ProductName = "Bilgisayar", Price = 32_500 },
					new Product() { ProductId = 2, ProductName = "Klavye", Price = 3_500 },
					new Product() { ProductId = 3, ProductName = "Monitör", Price = 9_850 },
					new Product() { ProductId = 4, ProductName = "Mouse", Price = 2_500 },
					new Product() { ProductId = 5, ProductName = "Deck", Price = 1_500 }
			);

			modelBuilder.Entity<Category>()
				.HasData(
				new Category() { CategoryId = 1, CategoryName = "Book" },
				new Category() { CategoryId = 2, CategoryName = "Computer" },
				new Category() { CategoryId = 3, CategoryName = "Monitor" },
				new Category() { CategoryId = 4, CategoryName = "Oem" },
				new Category() { CategoryId = 5, CategoryName = "Phone" }
				);
		}
	}
}
