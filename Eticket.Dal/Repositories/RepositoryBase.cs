using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Eticket.Dal.Entities;
using Tools;

namespace Eticket.Dal.Repositories
{
    public abstract class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity> 
        where TEntity : IEntity<TKey>
    {
        protected Connection Connection { get; }
        protected string TableName { get; }
        protected string IdName { get; }
        
        public RepositoryBase(string tableName, string idName)
        {
            Connection = new Connection(SqlClientFactory.Instance,
                "");
            TableName = tableName;
            IdName = idName;
        }

        protected abstract TEntity Convert(IDataRecord reader);
        

        public virtual TEntity Get(TKey id)
        {
            Command cmd = new Command("SELECT * FROM [" + TableName + "] " +
                                      "WHERE " + IdName + " = @Id");
            cmd.AddParameter("@Id", id);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [" + TableName + "]");

            return Connection.ExecuteReader(cmd, Convert);
        }

        public abstract bool Update(TEntity data);

        public abstract bool Delete(TKey id);
        
        public abstract TKey Insert(TEntity entity);
    }
}