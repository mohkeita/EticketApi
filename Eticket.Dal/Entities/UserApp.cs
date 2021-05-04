using System;

namespace Eticket.Dal.Entities
{
    public class UserApp : IEntity<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateBirth { get; set; }
        public string Password { get; set; }
        public bool Blocked { get; set; }
        public bool IsAdmin { get; set; }
        
    }
}