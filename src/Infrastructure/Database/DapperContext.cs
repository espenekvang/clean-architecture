using System.Data;
using Microsoft.Data.Sqlite;

namespace Infrastructure.Database
{
    internal class DapperContext
    {
        public IDbConnection CreateConnection() => new SqliteConnection("Data Source=power.db");
    }
}
