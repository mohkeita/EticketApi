using System.ComponentModel.DataAnnotations;

namespace Eticket.Api.Models.Dto
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
        public string Name { get; set; }
    }
}