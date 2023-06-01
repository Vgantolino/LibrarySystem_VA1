using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem_VA.EntityFrameworkCore
{
    public static class LibrarySystem_VADbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LibrarySystem_VADbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LibrarySystem_VADbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
