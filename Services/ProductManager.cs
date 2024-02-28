using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class ProductManager : IProductService
	{
		private readonly IRepositoryManager _manager;

		public ProductManager(IRepositoryManager manager)
		{
			_manager = manager;
		}

		public void CreateProduct(Product product)
		{
			_manager.Product.Create(product);
			_manager.Save();
		}

		public void DeleteOneProduct(int id)
		{
			Product product = GetOneProduct(id, false);
			if (product != null)
			{
				_manager.Product.DeleteOneProduct(product);
				_manager.Save();
			}
		}

		public IEnumerable<Product> GetAllProducts(bool trackChanges)
		{
			return _manager.Product.GetAllProducts(trackChanges);
		}

		public Product? GetOneProduct(int id, bool trackChanges)
		{
			var product = _manager.Product.GetOneProduct(id, trackChanges);

			if (product is null)
				throw new Exception("Product Not Found!");

			return product;
		}

		public void UpdateOneProduct(Product product)
		{
			var entity = _manager.Product.GetOneProduct(product.ProductId, true);
			if (entity is null)
				throw new Exception("Product Not Found");

			entity.ProductName = product.ProductName;
			entity.Price = product.Price;

			_manager.Save();

		}
	}
}
