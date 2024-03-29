﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class Product
	{
		public int ProductId { get; set; }
		public string? ProductName { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int? CategoryId { get; set; }
		public Category? Category { get; set; }
		public string? Summary { get; set; } = string.Empty;
		public string? ImageUrl { get; set; }
	}
}
