using Microsoft.AspNetCore.Mvc;

namespace MultipartFormWebAPITest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
