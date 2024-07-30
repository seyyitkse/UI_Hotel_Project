using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents._SpinnerPartial
{
    public class _SpinnerPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
