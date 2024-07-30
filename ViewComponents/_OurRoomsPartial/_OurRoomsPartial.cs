using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents._OurRoomsPartial
{
    public class _OurRoomsPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
