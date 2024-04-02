using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;
using WebApplication2.Models.IRepository;

namespace WebApplication2.Pages
{
    public class CheckoutPageModel : PageModel
    {

        private readonly IOrderRepository _OrderRepository;
        private readonly IShoppingCart _ShoppingCart;

        public CheckoutPageModel(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _OrderRepository = orderRepository;
            _ShoppingCart = shoppingCart;
        }



        [BindProperty]
        public Order Order { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var items = _ShoppingCart.GetShoppingCartItems();
            _ShoppingCart.ShoppingCartItems = items;


            if (_ShoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (ModelState.IsValid)
            {
                _OrderRepository.CreateOrder(Order);
                _ShoppingCart.ClearCart();
                return RedirectToAction("CheckoutCompletePage");
            }
            return Page();
        }
    }
}
