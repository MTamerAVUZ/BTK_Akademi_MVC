using AutoMapper;
using Entities.Dtos;
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
		private readonly IMapper _mapper;
		public ProductManager(IRepositoryManager manager, IMapper mapper)
		{
			_manager = manager;
			_mapper = mapper;
		}

		public void CreateProduct(ProductDtoForInsertion productDto)
		{
			//Product productDto = new Product()
			//{
			//	ProductName = productDto.ProductName,
			//	Price = productDto.Price,
			//	CategoryId = productDto.CategoryId,
			//};

			Product product = _mapper.Map<Product>(productDto);  //automapper
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

		public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
		{
			var product = GetOneProduct(id, trackChanges);
			var productDto = _mapper.Map<ProductDtoForUpdate>(product);

			return productDto;
		}

		public void UpdateOneProduct( ProductDtoForUpdate productDto)
		{
			//var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);
			//if (entity is null)
			//	throw new Exception("Product Not Found!! ");
			//entity = _mapper.Map<Product>(productDto);
			//_mapper.Map(productDto, entity);

			var entity = _mapper.Map<Product>(productDto);

			_manager.Product.UpdateOneProduct(entity);
			_manager.Save();


		//entity.ProductName = productDto.ProductName;
			//entity.Price = productDto.Price;
			//entity.CategoryId = productDto.CategoryId;
		}
	}
}
