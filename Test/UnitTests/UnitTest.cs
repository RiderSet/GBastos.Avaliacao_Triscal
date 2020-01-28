using CRUD.InfraEstructure.Data.Contexts;
using CRUD.InfraEstructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests
{
    public class UnitTest
    {
        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Avaliacao_Gil")
                .Options;

            using (var context = new Context(options))
            {
                //var service = new Cliente_Rep();
                //service.Add_Async();   //("https://example.com");
                context.SaveChanges();
            }
        }
    }
}
