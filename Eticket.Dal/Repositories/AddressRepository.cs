using System.Data;
using Eticket.Dal.Entities;
using Tools;

namespace Eticket.Dal.Repositories
{
    public class AddressRepository : RepositoryBase<int, Address>
    {
        public AddressRepository() : base("Address", "AddressId")
        {
        }

        protected override Address Convert(IDataRecord reader)
        {
            return new Address()
            {
                Id = (int) reader["AddressId"],
                Street = reader["Street"].ToString(),
                City = reader["City"].ToString()

            };
        }

        public override bool Update(Address data)
        {
            Command cmd = new Command("UpdateOrganizers", true);
            cmd.AddParameter("@Id", data.Id);
            cmd.AddParameter("@street", data.Street);
            cmd.AddParameter("@city", data.City);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int id)
        {
            Command cmd = new Command("DeleteAddress", true);
            cmd.AddParameter("@IdAddress", id);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override int Insert(Address entity)
        {
            Command cmd = new Command("AddAdress", true);
            cmd.AddParameter("@street", entity.Street);
            cmd.AddParameter("@city", entity.City);

            return (int)Connection.ExecuteScalar(cmd);
        }
    }
}