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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
		{
			ViewBag.Kategoriler = GetCategoriesSelectList();
			if (ModelState.IsValid)
			{
				//file operation!! 
				string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);   //   a/b/c/...

				using (var stream = new FileStream(path,FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				productDto.ImageUrl = String.Concat("/images/", file.FileName);  //concat ile /images/ ile dosya adını birleştirdik. 

				_manager.ProductService.CreateProduct(productDto);
				return RedirectToAction("Index");
			}

			return View(productDto);

		}
		private SelectList GetCategoriesSelectList()
		{
			return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName");
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
		public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
		{
			ViewBag.Kategoriler = GetCategoriesSelectList();
			if (ModelState.IsValid)
			{
				//file operation!! 
				string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);   //   a/b/c/...

				using (var stream = new FileStream(path, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				productDto.ImageUrl = String.Concat("/images/", file.FileName);  //concat ile /images/ ile dosya adını birleştirdik. 
				_manager.ProductService.UpdateOneProduct(productDto);
				return RedirectToAction("Index");
			}

			return View(productDto);
		}

		
		public IActionResult Delete([FromRoute(Name ="id")] int id)
		{			
			
			_manager.ProductService.DeleteOneProduct(id);

			return RedirectToAction("Index");
		}


	}
}
