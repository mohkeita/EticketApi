namespace Eticket.Dal.Entities
{
    public class Tickets : IEntity<int>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int Rest { get; set; }
    }
}