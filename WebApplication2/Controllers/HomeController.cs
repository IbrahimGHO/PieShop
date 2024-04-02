using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.IRepository;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;

        }
        public IActionResult Index()
        {
            var PiesOfTheWeek = _pieRepository.PiesOfTheWeek;
            var homeViewModel = new HomeViewModel(PiesOfTheWeek);
            return View(homeViewModel);
        }
    }
}
