using WebApplication2.Models.IRepository;

namespace WebApplication2.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IShoppingCart ShoppingCart { get; }
        public decimal ShoppingCartTotal { get; }
        public ShoppingCartViewModel(IShoppingCart shoppingCart , decimal shoppingCartTotal)
        {
            ShoppingCart= shoppingCart;
            ShoppingCartTotal= shoppingCartTotal;
        }
    }
}
