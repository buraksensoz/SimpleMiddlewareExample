using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace MiddlewareSampleProject.App.Controllers
{
    public class HomeController : Controller
    {
      

        public HomeController(ILogger<HomeController> logger)
        {
           
        }

        public IActionResult Index()
        {
            return View();
        }



    }
}
