namespace Eticket.Dal.Entities
{
    public class Address : IEntity<int>
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}