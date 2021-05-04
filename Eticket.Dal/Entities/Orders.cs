namespace Eticket.Dal.Entities
{
    public class Orders : IEntity<int>
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}