using System.ComponentModel.DataAnnotations;

namespace Eticket.Api.Models.Dto
{
    public class EventDto
    {
        [Required(ErrorMessage = "UserId is a required field.")]
        public int UserId { get; set; }
        
        [Required(ErrorMessage = "OrganizersId is a required field.")]
        public int OrganizersId { get; set; }
        
        [Required(ErrorMessage = "CategoryId is a required field.")]
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Title is 50 characters.")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "description is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Description is 100 characters.")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "DateEvent is a required field.")]
        public string DateEvent { get; set; }
        
        [Required(ErrorMessage = "Street is a required field.")]
        public string Street { get; set; }
        
        [Required(ErrorMessage = "City is a required field.")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Quantity is a required field.")]
        public int Quantity { get; set; }
        
        [Required(ErrorMessage = "Quantity is a required field.")]
        public decimal UnitPrice { get; set; }
    }
}