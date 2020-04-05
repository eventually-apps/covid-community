using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CovidCommunity.Api.EntityFrameworkCore
{
    public static class ApiDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ApiDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ApiDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
