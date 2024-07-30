using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents._HeaderPartial
{
    public class _HeaderPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
