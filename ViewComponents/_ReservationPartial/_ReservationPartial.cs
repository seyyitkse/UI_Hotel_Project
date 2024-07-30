using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents._ReservationPartial
{
    public class _ReservationPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
