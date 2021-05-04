namespace Eticket.Dal.Entities
{
    public class Event : IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrganizersId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DateEvent { get; set; }
        public int AddressId { get; set; }
        public int TicketId { get; set; }
        
        
    }
}