namespace WebApplication2.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _BethanysPieShopDbContext;


        public CategoryRepository(BethanysPieShopDbContext context)
        {
            _BethanysPieShopDbContext = context;
        }


        public IEnumerable<Category> AllCategories => _BethanysPieShopDbContext.Categories.OrderBy(p => p.CategoryName);

    }
}
