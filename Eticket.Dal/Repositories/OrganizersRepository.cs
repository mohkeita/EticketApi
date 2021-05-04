using System.Data;
using Eticket.Dal.Entities;
using Tools;

namespace Eticket.Dal.Repositories
{
    public class OrganizersRepository : RepositoryBase<int, Organizers>
    {
        public OrganizersRepository() : base("Organizers", "OrganizersId")
        {
        }

        protected override Organizers Convert(IDataRecord reader)
        {
            return new Organizers()
            {
                Id = (int) reader["OrganizersId"],
                Name = reader["Name"].ToString(),
                Email = reader["Email"].ToString(),
                Phone = reader["Phone"].ToString(),
                About = reader["About"].ToString()
            };
        }

        public override bool Update(Organizers data)
        {
            Command cmd = new Command("UpdateOrganizers", true);
            cmd.AddParameter("@Id", data.Id);
            cmd.AddParameter("@Name", data.Name);
            cmd.AddParameter("@Email", data.Email);
            cmd.AddParameter("@Phone", data.Phone);
            cmd.AddParameter("@About", data.About);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int id)
        {
            Command cmd = new Command("DeleteOrganizers", true);
            cmd.AddParameter("@IdOrganizers", id);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override int Insert(Organizers entity)
        {
            Command cmd = new Command("AddOrganizers", true);
            cmd.AddParameter("@name", entity.Name);
            cmd.AddParameter("@email", entity.Email);
            cmd.AddParameter("@phone", entity.Phone);
            cmd.AddParameter("@about", entity.About);

            return (int)Connection.ExecuteScalar(cmd);
        }
    }
}