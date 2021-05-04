namespace Eticket.Api.Models.Dto
{
    public class UserWithToken
    {
        public int Id { get; set; }
        public bool Role { get; set; }
        public string FullLastname { get; set; }
        public string Token { get; set; }
    }
}