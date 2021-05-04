using System;
using System.Data;
using System.Linq;
using Eticket.Dal.Entities;
using Tools;

namespace Eticket.Dal.Repositories
{
    public class UserAppRepository : RepositoryBase<int, UserApp>
    {
        public UserAppRepository() : base("UserApp", "UserId")
        {
        }

        protected override UserApp Convert(IDataRecord reader)
        {
            return new UserApp()
            {
                Id = (int) reader["UserId"],
                Username = reader["Username"].ToString(),
                Email = reader["Email"].ToString(),
                Firstname = reader["Firstname"].ToString(),
                Lastname = reader["Lastname"].ToString(),
                DateBirth = (DateTime) reader["DateBirth"],
                Password = null,
                Blocked = (bool) reader["Blocked"],
                IsAdmin = (bool) reader["IsAdmin"]
            };
        }
        
        public UserApp Login(string email, string password)
        {
            Command cmd = new Command("Login", true);
            cmd.AddParameter("@Email", email);
            cmd.AddParameter("@Password", password);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public override bool Update(UserApp data)
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete(int id)
        {
            Command cmd = new Command("DeleteUser", true);
            cmd.AddParameter("@Id", id);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override int Insert(UserApp entity)
        {
            Command cmd = new Command("AddUser", true);
            cmd.AddParameter("@Username", entity.Username);
            cmd.AddParameter("@Email", entity.Email);
            cmd.AddParameter("@Firstname", entity.Firstname);
            cmd.AddParameter("@Lastname", entity.Lastname);
            cmd.AddParameter("@DateBirth", entity.DateBirth);
            cmd.AddParameter("@Password", entity.Password);
            cmd.AddParameter("@IsAdmin", 0);

            return (int)Connection.ExecuteScalar(cmd);
        }
        
        public bool BlockUnBlockUser(UserApp data)
        {
            Command cmd = new Command("BlockUnBlockUser", true);
            cmd.AddParameter("@IdUser", data.Id);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}