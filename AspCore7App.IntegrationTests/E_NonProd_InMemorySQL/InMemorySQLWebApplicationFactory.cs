using AspCore7App.Data;
using AspCore7App.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace AspCore7App.IntegrationTests.E_NonProd_InMemorySQL
{
    /// <summary>
    /// IN MEMORY IS NOT RECOMMENDED FOR TESTING
    /// </summary>
    public class InMemorySQLWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove DbContextOptions
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                services.Remove(dbContextDescriptor);

                services.AddDbContext<ApplicationDbContext>((optBuilder) =>
                {
                    optBuilder.UseInMemoryDatabase("BloggingControllerTest")
                        .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));

                    SeedData(optBuilder);
                });
            });

            builder.UseEnvironment("Development");
        }

        private static void SeedData(DbContextOptionsBuilder optBuilder)
        {
            // Create the schema and seed some data
            var context = new ApplicationDbContext((DbContextOptions<ApplicationDbContext>)optBuilder.Options);

            context.Database.EnsureCreated();

            context.AddRange(
                new Country { Id = 1, Name = "Türkiye", Population = 123456789 },
                new Country { Id = 2, Name = "Namibia", Population = 555 });
            context.SaveChanges();

        }
    }
}
