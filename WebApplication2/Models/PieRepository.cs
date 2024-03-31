using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopDbContext _BethanysPieShopDbContext;

        public PieRepository(BethanysPieShopDbContext context)
        {
            _BethanysPieShopDbContext = context;
        }

        public IEnumerable<Pie> AllPies
        {
            get { return _BethanysPieShopDbContext.Pies.Include(c => c.Category); }

        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get { return _BethanysPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek); }

        }

        public Pie? GetPieById(int id)
        {
            return _BethanysPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == id);
        }

        public IEnumerable<Pie> searchPies(string searchQuery)
        {
            return _BethanysPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery) );
        }
    }
}
