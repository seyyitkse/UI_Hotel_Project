using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5077/api/Contact");
            var responseMessage2 = await client.GetAsync($"http://localhost:5077/api/SendMessage/GetSendMessageCount");
            var responseMessage3 = await client.GetAsync($"http://localhost:5077/api/Contact/GetContactCount");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode && responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                ViewBag.SendMessageCount = jsonData2;
                ViewBag.ContactMessageCount = jsonData3;
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
        {
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            model.SenderMail = "admin@mail.com";
            model.SenderName = "Admin";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5077/api/SendMessage", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Inbox");
            }
            return View();
        }
        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5077/api/SendMessage");
            var responseMessage2 = await client.GetAsync($"http://localhost:5077/api/SendMessage/GetSendMessageCount");
            var responseMessage3 = await client.GetAsync($"http://localhost:5077/api/Contact/GetContactCount");

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode && responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);
                ViewBag.SendMessageCount = jsonData2;
                ViewBag.ContactMessageCount = jsonData3;
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5077/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsSendbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5077/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultSendMessageDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public PartialViewResult SidebarAdminContactPartialAsync()
        {
            return PartialView();
        }

        public  PartialViewResult SidebarAdminContactCategoryPartialAsync()
        {
      
            return PartialView();
        }
    }
}
