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

        public PartialViewResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(CreateBookingDto createBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            // Optional sample logic
            createBookingDto.Description = string.Empty;
            createBookingDto.Status = "Pending";

            // Ensure CheckInDate and CheckOutDate are formatted correctly
            var checkInDateFormatted = createBookingDto.CheckInDate?.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            var checkOutDateFormatted = createBookingDto.CheckOutDate?.ToString("yyyy-MM-ddTHH:mm:ss.fff");

            // Prepare the data with formatted dates
            var bookingData = new
            {
                createBookingDto.Name,
                createBookingDto.Mail,
                CheckInDate = checkInDateFormatted,
                CheckOutDate = checkOutDateFormatted,
                createBookingDto.AdultCount,
                createBookingDto.ChildCount,
                createBookingDto.RoomCount,
                createBookingDto.SpecialRequests,
                createBookingDto.Description,
                createBookingDto.Status
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(bookingData);
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
