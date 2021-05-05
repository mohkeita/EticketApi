using System.ComponentModel.DataAnnotations;

namespace Eticket.Api.Models.Dto
{
    public class OrderDto
    {
        [Required(ErrorMessage = "TicketId is a required field.")]
        public int TicketId { get; set; }
        
        [Required(ErrorMessage = "UserId is a required field.")]
        public int UserId { get; set; }
        
        [Required(ErrorMessage = "Quantity is a required field.")]
        public int Quantity { get; set; }
    }
}