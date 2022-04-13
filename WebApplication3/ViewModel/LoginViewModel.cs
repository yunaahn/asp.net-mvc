using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "입력하세요")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "입력하세요")]
        public string UserPassword { get; set; }


    }
}
