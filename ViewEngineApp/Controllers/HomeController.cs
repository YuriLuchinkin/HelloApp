using Microsoft.AspNetCore.Mvc;
 
namespace ViewEngineApp.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult About()
        {
            return View();
        }
        public ViewResult Contact()
        {
            return View();
        }
    }
}