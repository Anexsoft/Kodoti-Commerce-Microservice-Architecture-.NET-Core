using Catalog.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Tests.Config
{
    public static class ApplicationDbContextInMemory
    {
        public static DbContextOptions<ApplicationDbContext> Get() 
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"Catalog.Db")
                .Options;
        }
    }
}
