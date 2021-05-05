using System.ComponentModel.DataAnnotations;

namespace Eticket.Api.Models.Dto
{
    public class TicketDto
    {
        [Required(ErrorMessage = "Quantity is a required field.")]
        public int Quantity { get; set; }
        
        [Required(ErrorMessage = "UnitPrice is a required field.")]
        public decimal UnitPrice { get; set; }
    }
}