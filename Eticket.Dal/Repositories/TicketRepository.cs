using System.Data;
using Eticket.Dal.Entities;
using Tools;

namespace Eticket.Dal.Repositories
{
    public class TicketRepository : RepositoryBase<int, Tickets>
    {
        public TicketRepository() : base("Tickets", "TicketId")
        {
        }

        protected override Tickets Convert(IDataRecord reader)
        {
            return new Tickets()
            {
                Id = (int) reader["TicketId"],
                Quantity = (int) reader["Quantity"],
                UnitPrice = (decimal) reader["UnitPrice"],
                Rest = (int) reader["Rest"]
            };
        }

        public override bool Update(Tickets data)
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override int Insert(Tickets entity)
        {
            Command cmd = new Command("AddTicket", true);
            cmd.AddParameter("@quantity", entity.Quantity);
            cmd.AddParameter("@unitPrice", entity.UnitPrice);

            return (int)Connection.ExecuteScalar(cmd);
        }
    }
}