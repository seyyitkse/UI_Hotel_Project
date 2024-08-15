using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.SubscribeDto
{
    public class CreateSubscribeDto
    {
        [Required(ErrorMessage = "Email adresi giriniz!")]
        public string? Mail { get; set; }
    }
}
