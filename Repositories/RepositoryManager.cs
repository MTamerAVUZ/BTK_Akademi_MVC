using Repositories.Contracts;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class RepositoryManager : IRepositoryManager
	{


		private readonly RepositoryContext _context;
		private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;
		public RepositoryManager(IProductRepository productRepository, 
			ICategoryRepository categoryRepository, 
			RepositoryContext context)
		{
			_categoryRepository = categoryRepository;
			_context = context;
			_productRepository = productRepository;
		}

		public IProductRepository Product => _productRepository;

		public ICategoryRepository Category => _categoryRepository;

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
