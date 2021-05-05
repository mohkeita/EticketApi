using System.ComponentModel.DataAnnotations;

namespace Eticket.Api.Models.Dto
{
    public class OrganizersDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "About is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Phone is 50 characters.")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "About is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the About is 50 characters.")]
        public string About { get; set; }
    }
}