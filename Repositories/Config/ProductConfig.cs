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
				  new Product() { ProductId = 1, CategoryId = 2,ImageUrl="/images/1.jpg", ProductName = "Bilgisayar", Price = 32_500 },
					new Product() { ProductId = 2, CategoryId = 2,ImageUrl="/images/2.jpg", ProductName = "Klavye", Price = 3_500 },
					new Product() { ProductId = 3, CategoryId = 3,ImageUrl="/images/3.jpg", ProductName = "Monitör", Price = 9_850 },
					new Product() { ProductId = 4, CategoryId = 2,ImageUrl="/images/4.jpg", ProductName = "Mouse", Price = 2_500 },
					new Product() { ProductId = 5, CategoryId = 5,ImageUrl="/images/5.jpg", ProductName = "Deck", Price = 1_500 },
					new Product() { ProductId = 6, CategoryId = 1,ImageUrl="/images/6.jpg", ProductName = "History", Price = 25 },
					new Product() { ProductId = 7, CategoryId = 1,ImageUrl="/images/7.jpg", ProductName = "Hamlett", Price = 45 }
				);
		}
	}
}
