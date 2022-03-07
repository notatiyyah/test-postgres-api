using Microsoft.EntityFrameworkCore;

namespace PostgresTest.V1.Infrastructure
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserDb> Users { get; set; }
    }
}
