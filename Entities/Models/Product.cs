﻿using System;
using System.Collections.Generic;
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


		// public string Description { get; set; }
	}
}