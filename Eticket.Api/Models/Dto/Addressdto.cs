using System.ComponentModel.DataAnnotations;

namespace Eticket.Api.Models.Dto
{
    public class AddressDto
    {
        [Required(ErrorMessage = "Street is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Street is 50 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the City is 50 characters.")]
        public string City { get; set; }
    }
}