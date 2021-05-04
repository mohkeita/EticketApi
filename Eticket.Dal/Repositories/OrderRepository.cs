using System.Data;
using Eticket.Dal.Entities;
using Tools;

namespace Eticket.Dal.Repositories
{
    public class OrderRepository : RepositoryBase<int, Orders>
    {
        public OrderRepository() : base("Orders", "OrdersId")
        {
        }
        
        protected override Orders Convert(IDataRecord reader)
        {
            return new Orders()
            {
                Id = (int) reader["OrdersId"],
                TicketId = (int) reader["TicketId"],
                UserId = (int) reader["UserId"],
                Quantity = (int) reader["Quantity"],
                Total = (decimal) reader["Total"]
            };
        }
        

        public override bool Update(Orders data)
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override int Insert(Orders entity)
        {
            Command cmd = new Command("OrderTicket", true);
            cmd.AddParameter("@ticketId", entity.TicketId);
            cmd.AddParameter("@userId", entity.UserId);
            cmd.AddParameter("@quantity", entity.Quantity);

            return (int)Connection.ExecuteScalar(cmd);
        }
        
    }
}