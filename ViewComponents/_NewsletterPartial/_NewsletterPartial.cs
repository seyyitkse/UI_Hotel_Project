using Microsoft.AspNetCore.Mvc;
namespace HotelProject.WebUI.ViewComponents._NewsletterPartial
{
    public class _NewsletterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
