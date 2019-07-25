using Linktrix.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Linktrix.API.UnitTests.Context
{
    public class DbContextMocker
    {
        public static AppDbContext GetAppDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var dbContext = new AppDbContext(options);

            dbContext.Seed();

            return dbContext;
        }
    }
}
