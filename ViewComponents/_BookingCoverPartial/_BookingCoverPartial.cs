using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents._BookingCoverPartial
{
    public class _BookingCoverPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
