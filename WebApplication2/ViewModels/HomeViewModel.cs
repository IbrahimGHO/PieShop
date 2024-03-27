using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get;}

   
        public HomeViewModel(IEnumerable<Pie> piesOfTheWeek)
        {
            PiesOfTheWeek= piesOfTheWeek;
        }
    }
}
