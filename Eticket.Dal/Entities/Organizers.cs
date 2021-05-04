namespace Eticket.Dal.Entities
{
    public class Organizers : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string About { get; set; }
    }
}