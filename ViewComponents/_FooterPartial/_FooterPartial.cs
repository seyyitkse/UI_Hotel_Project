using Microsoft.AspNetCore.Mvc;
namespace HotelProject.WebUI.ViewComponents._FooterPartial
{
    public class _FooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
