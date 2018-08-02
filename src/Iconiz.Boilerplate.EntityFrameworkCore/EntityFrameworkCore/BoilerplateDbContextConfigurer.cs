using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Iconiz.Boilerplate.EntityFrameworkCore
{
    public static class BoilerplateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BoilerplateDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BoilerplateDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}