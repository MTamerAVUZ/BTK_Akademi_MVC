﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(c => c.CategoryId);
			builder.Property(c => c.CategoryName).IsRequired();


			builder.HasData(
				new Category() { CategoryId = 1, CategoryName = "Book" },
				new Category() { CategoryId = 2, CategoryName = "Computer" },
				new Category() { CategoryId = 3, CategoryName = "Monitor" },
				new Category() { CategoryId = 4, CategoryName = "Oem" },
				new Category() { CategoryId = 5, CategoryName = "Phone" }
				);
		}
	}
}
