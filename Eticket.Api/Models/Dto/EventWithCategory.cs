using Eticket.Dal.Entities;

namespace Eticket.Api.Models.Dto
{
    public class EventWithCategory
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string DateEvent { get; set; }
        
    }
}