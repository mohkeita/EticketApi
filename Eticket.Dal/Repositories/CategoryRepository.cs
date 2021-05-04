using System.Data;
using Eticket.Dal.Entities;
using Tools;

namespace Eticket.Dal.Repositories
{
    public class CategoryRepository : RepositoryBase<int, Category>
    {
        public CategoryRepository() : base("Category", "CategoryId")
        {
        }

        protected override Category Convert(IDataRecord reader)
        {
            return new Category()
            {

                Id = (int) reader["CategoryId"],
                Name = reader["Name"].ToString()
            };
        }

        public override bool Update(Category data)
        {
            Command cmd = new Command("UpdateCategory", true);
            cmd.AddParameter("@Id", data.Id);
            cmd.AddParameter("@Name", data.Name);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int id)
        {
            Command cmd = new Command("DeleteCategory", true);
            cmd.AddParameter("@Id", id);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override int Insert(Category entity)
        {
            Command cmd = new Command("AddCategory", true);
            cmd.AddParameter("@name", entity.Name);

            return (int)Connection.ExecuteScalar(cmd);
        }
    }
}