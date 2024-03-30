using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IShoppingCart _ShoppingCart;

        public OrderController(IOrderRepository orderRepository , IShoppingCart shoppingCart)
        {
            _OrderRepository= orderRepository;
            _ShoppingCart= shoppingCart;

        }

        public IActionResult Checkout() { return View(); }
    }
}
