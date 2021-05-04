namespace Eticket.Dal.Entities
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}