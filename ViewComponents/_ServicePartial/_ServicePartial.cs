using Microsoft.AspNetCore.Mvc;
namespace HotelProject.WebUI.ViewComponents._ServicePartial
{
    public class _ServicePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
