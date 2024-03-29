﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class Cart
	{
		public Cart()
		{
			Lines = new List<CartLine>();
		}
		public List<CartLine> Lines { get; set; }

		public void AddItem(Product product, int quantity)
		{
			CartLine? line = Lines.Where(l => l.Product.ProductId == product.ProductId).FirstOrDefault();

			if (line is null)
			{
				Lines.Add(new CartLine()
				{
					Product = product,
					Quantity = quantity
				});

			}
			else
			{
				line.Quantity += quantity;
			}
		}

		public void RemoveLine(Product product) => Lines.RemoveAll(l=>l.Product.ProductId.Equals(product.ProductId));

		public decimal ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);

		public void Clear ()=>Lines.Clear();
	}


}
