using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents._HeadPartial
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
