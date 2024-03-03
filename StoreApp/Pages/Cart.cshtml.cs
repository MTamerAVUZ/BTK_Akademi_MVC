using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
	public class CartModel : PageModel
	{
		private readonly IServiceManager _manager;	
		public Cart Cart { get; set; }//IoC kayd� olacak

		public CartModel(IServiceManager manager, Cart cart)
		{
			Cart = cart;
			_manager = manager;
		}


		public string ReturnUrl { get; set; } = "/";

		public void OnGet(string returnUrl) //kullan�c� sayfan�n herhangi bri yerinden cart a geldi�inde ve geri tu�una bast���nda geldi�i yere geri y�nlendirmek i�in 
		{
			ReturnUrl = returnUrl ?? "/";

		}

		public IActionResult OnPost(int productId, string returnUrl)
		{
			Product? product = _manager.ProductService.GetOneProduct(productId, false);

			if (product is not null)
			{
				Cart.AddItem(product, 1);
			}

			return Page(); //return Url logic i�lenecek

		}

		public IActionResult OnPostRemove(int id, string returnUrl)
		{
			Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);

			return Page(); 
		}
	}
}
