using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(CreateBookingDto createBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            // Sample logic, you can modify or remove
            createBookingDto.TotalPrice = 1000;
            createBookingDto.Description = string.Empty;
            createBookingDto.SpecialRequests ="No special requests";
            createBookingDto.Status = "Pending";
            createBookingDto.CreatedDate = DateTime.Now;
            createBookingDto.UpdatedDate = DateTime.Now;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent jsonService = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:5077/api/Reserve", jsonService);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // You may log the error or provide feedback to the user
                ModelState.AddModelError("", "Booking failed. Please try again.");
                return View("Index");
            }
        }
    }
}
