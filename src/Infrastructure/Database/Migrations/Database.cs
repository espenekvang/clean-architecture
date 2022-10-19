using Dapper;

namespace Infrastructure.Database.Migrations
{
    internal class Database
    {
        private readonly DapperContext _context;

        public Database(DapperContext context)
        {
            _context = context;
        }

    }
}
