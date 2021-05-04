using System;
using System.ComponentModel.DataAnnotations;

namespace Eticket.Api.Models.Dto
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Username is a required field")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Username is 50 characters.")]
        public string Username { get; set; }
        
        [EmailAddress]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Firstname is a required field")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Firstname is 50 characters.")]
        public string Firstname { get; set; }
        
        [Required(ErrorMessage = "Lastname is a required field")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Lastname is 50 characters.")]
        public string Lastname { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateBirth { get; set; }
        
        [StringLength(50,MinimumLength = 8,ErrorMessage ="The length for the Password must ne between 8 and 32")]
        public string Password { get; set; }
    }
}