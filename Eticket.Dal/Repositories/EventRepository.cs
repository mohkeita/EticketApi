using System.Collections.Generic;
using System.Data;
using Eticket.Dal.Entities;
using Tools;

namespace Eticket.Dal.Repositories
{
    public class EventRepository : RepositoryBase<int, Event>
    {
        public EventRepository() : base("Events", "EventId")
        {
        }

        protected override Event Convert(IDataRecord reader)
        {
            return new Event()
            {
                Id = (int) reader["EventId"],
                UserId = (int) reader["UserId"],
                OrganizersId = (int) reader["OrganizersId"],
                CategoryId = (int) reader["CategoryId"],
                Title =  reader["Title"].ToString(),
                Description =  reader["Description"].ToString(),
                DateEvent =  reader["DateEvent"].ToString(),
                AddressId =  (int) reader["AddressId"],
                TicketId =  (int) reader["TicketId"]
            };
        }
        
        public IEnumerable<Event> GetAllUser()
        {
            Command cmd = new Command("ReadEventAll", true);

            return Connection.ExecuteReader(cmd, Convert);
        }

        public override bool Update(Event data)
        {
            Command cmd = new Command("UpdateOrganizers", true);
            cmd.AddParameter("@Id", data.Id);
            cmd.AddParameter("@IdOrganizers", data.OrganizersId);
            cmd.AddParameter("@IdCategory", data.CategoryId);
            cmd.AddParameter("@Title", data.Title);
            cmd.AddParameter("@Description", data.Description);
            cmd.AddParameter("@DateEvent", data.DateEvent);
            cmd.AddParameter("@IdAddress", data.AddressId);
            cmd.AddParameter("@IdTicket", data.TicketId);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override int Insert(Event entity)
        {
            Command cmd = new Command("AddEvents", true);
            cmd.AddParameter("@UserId", entity.UserId);
            cmd.AddParameter("@OrganizersId", entity.OrganizersId);
            cmd.AddParameter("@CategoryId", entity.CategoryId);
            cmd.AddParameter("@title", entity.Title);
            cmd.AddParameter("@description", entity.Description);
            cmd.AddParameter("@dateEvent", entity.DateEvent);
            cmd.AddParameter("@addressId", entity.AddressId);
            cmd.AddParameter("@TicketId", entity.TicketId);

            return (int)Connection.ExecuteScalar(cmd);
        }
    }
}