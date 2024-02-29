using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.ProductId);
			builder.Property(p => p.ProductName).IsRequired();
			builder.Property(p => p.Price).IsRequired();


			builder.HasData(
				new Product() { ProductId = 1, CategoryId = 2, ProductName = "Bilgisayar", Price = 32_500 },
					new Product() { ProductId = 2, CategoryId = 2, ProductName = "Klavye", Price = 3_500 },
					new Product() { ProductId = 3, CategoryId = 3, ProductName = "Monitör", Price = 9_850 },
					new Product() { ProductId = 4, CategoryId = 2, ProductName = "Mouse", Price = 2_500 },
					new Product() { ProductId = 5, CategoryId = 5, ProductName = "Deck", Price = 1_500 },
					new Product() { ProductId = 6, CategoryId = 1, ProductName = "History", Price = 25 },
					new Product() { ProductId = 7, CategoryId = 1, ProductName = "Hamlett", Price = 45 }
				);
		}
	}
}
