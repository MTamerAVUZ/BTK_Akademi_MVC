using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IServiceManager _manager;

		public ProductController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var model = _manager.ProductService.GetAllProducts(false);
			return View(model);
		}

		public IActionResult Create()
		{
			ViewBag.Kategoriler = GetCategoriesSelectList();
			return View();
		}

		private SelectList GetCategoriesSelectList()
		{
			return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName");
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] ProductDtoForInsertion productDto)
		{
			if (ModelState.IsValid)
			{
				_manager.ProductService.CreateProduct(productDto);
				return RedirectToAction("Index");
			}

			return View(productDto);

		}

		[HttpGet]
		public IActionResult Update([FromRoute(Name ="id")]int id)
		{
			ViewBag.Kategoriler = GetCategoriesSelectList();

			var data= _manager.ProductService.GetOneProductForUpdate(id, false);
			return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update([FromForm] ProductDtoForUpdate product)
		{
			if (ModelState.IsValid)
			{
				_manager.ProductService.UpdateOneProduct(product);
				return RedirectToAction("Index");
			}

			return View(product);
		}

		
		public IActionResult Delete([FromRoute(Name ="id")] int id)
		{			
			
			_manager.ProductService.DeleteOneProduct(id);

			return RedirectToAction("Index");
		}


	}
}
