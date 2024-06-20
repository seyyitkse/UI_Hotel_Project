using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        //test
        public int a;
        public IActionResult Index()
        {
            return View();
        }
    }
}
