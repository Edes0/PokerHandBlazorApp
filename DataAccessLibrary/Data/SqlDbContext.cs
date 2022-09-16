using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Hand>? Hands { get; set; }
    }
}
