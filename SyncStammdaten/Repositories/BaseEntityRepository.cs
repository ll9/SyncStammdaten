using SyncStammdaten.Data;
using SyncStammdaten.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncStammdaten.Repositories
{
    public class BaseEntityRepository
    {
        private const string TableName = nameof(BaseEntity);
        private readonly AdoContext _adoContext;

        public BaseEntityRepository(AdoContext adoContext)
        {
            _adoContext = adoContext;
        }

        public DataTable List()
        {
            var query = $"SELECT * FROM {TableName}";

            using (var connection = _adoContext.GetConnection())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void SaveChanges(DataTable dataTable)
        {
            var query = $"SELECT * FROM {TableName}";

            using (var connection = _adoContext.GetConnection())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            {
                var commandBuilder = new SQLiteCommandBuilder(adapter);
                adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                adapter.InsertCommand = commandBuilder.GetInsertCommand();
                adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                adapter.Update(dataTable);
            }
        }
    }
}
