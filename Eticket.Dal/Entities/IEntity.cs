namespace Eticket.Dal.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}