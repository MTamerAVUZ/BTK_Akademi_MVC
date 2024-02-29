using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
	public record ProductDto
	{
		public int ProductId { get; init; }

		[DisplayName("Product Name")]
		[Required(ErrorMessage = "{0} is Required.. ")]		
		public string? ProductName { get; init; } = string.Empty;

		[DisplayName("Product Price")]
		[Required(ErrorMessage = "{0} is Required.. ")]
		public decimal Price { get; init; }
		[DisplayName("Product Category")]
		[Range(1, int.MaxValue)]
		[Required(ErrorMessage ="{0} is required..")]
		public int? CategoryId { get; init; }
		[DisplayName("Product Summary")]
		[Required(ErrorMessage ="{0} is required..")]
		public string? Summary { get; init; } = string.Empty;
		[DisplayName("Product Image")]
		//[Required(ErrorMessage ="{0} is required..")]
		public string? ImageUrl { get; set; }
	}
}
