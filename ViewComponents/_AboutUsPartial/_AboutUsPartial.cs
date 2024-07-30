using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents._AboutPartial
{
    public class _AboutUsPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
