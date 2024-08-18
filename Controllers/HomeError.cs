using Microsoft.AspNetCore.Mvc;

namespace _1907FirstWebAppAtempt.Controllers
{
    public class HomeError : Controller
    {
        public IActionResult Index()
        {
            return Content("oh no! Exception is Comming! Please come back later");
        }
    }
}
