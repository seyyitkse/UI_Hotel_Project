using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _NewsletterPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _NewsletterPartial(string email)
        {
            var createSubscribeDto = new CreateSubscribeDto
            {
                Mail = email
            };

            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("Mail", "Email adresi giriniz!");
                return PartialView();
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSubscribeDto);
            StringContent jsonService = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5077/api/Subscribe", jsonService);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return PartialView(); 
        }
    }
}
