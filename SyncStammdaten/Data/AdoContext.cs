using SyncStammdaten.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncStammdaten.Data
{
    public class AdoContext
    {
        public SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();
            return connection;
        }

        public void ExecuteQuery(string query)
        {
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void Migrate()
        {
            var query = $@"
create table if not exists {nameof(BaseEntity)} ({nameof(BaseEntity.Id)} TEXT DEFAULT (HEX(RANDOMBLOB(16))) PRIMARY KEY,
{nameof(BaseEntity.IsDeleted)} BOOLEAN, {nameof(BaseEntity.IsSynced)} BOOLEAN, {nameof(BaseEntity.Name)} TEXT,
{nameof(BaseEntity.Adress)} TEXT, {nameof(BaseEntity.Age)} INTEGER, {nameof(BaseEntity.Clock)} INTEGER)
";
            ExecuteQuery(query);
        }
    }
}
