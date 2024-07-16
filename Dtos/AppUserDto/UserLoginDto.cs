using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.AppUserDto
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Mail alanı boş geçilemez!")]
        [StringLength(50, ErrorMessage = "Mail alanı en fazla 50 karakter olabilir!")]
        [MinLengthAttribute(5, ErrorMessage = "Mail alanı en az 5 karakter olabilir!")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        [StringLength(50, ErrorMessage = "Şifre alanı en fazla 50 karakter olabilir!")]
        [MinLengthAttribute(5, ErrorMessage = "Şifre alanı en az 5 karakter olabilir!")]
        public string Password { get; set; }
    }
}
