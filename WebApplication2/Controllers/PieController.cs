using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class PieController : Controller
    {
       private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List() 
        {
            PieListViewModel pieListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese Cake");
            return View(pieListViewModel);
        
        }
    }
}
