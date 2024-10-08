using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminImageFileController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync("http://localhost:5077/api/FileImage", multipartFormDataContent);

            if (response.IsSuccessStatusCode)
            {
                // Handle successful upload
                ViewBag.Message = "File uploaded successfully!";
            }
            else
            {
                // Handle failure
                ViewBag.Message = "File upload failed!";
            }

            return RedirectToAction("Index");
        }
    }

}
