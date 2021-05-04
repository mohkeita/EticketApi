using System.ComponentModel.DataAnnotations;

namespace Eticket.Api.Models.Dto
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Email is a required field.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is a required field.")]
        public string Password { get; set; }
    }
}