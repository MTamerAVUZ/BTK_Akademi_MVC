using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		public String? CategoryName { get; set; } = string.Empty;

		public ICollection<Product> products { get; set; } //collection navigation property 


	}
}
