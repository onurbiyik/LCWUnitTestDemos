using AspCore7App.Data;
using AspCore7App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection.Metadata;

namespace AspCore7App.IntegrationTests.F_AuthenticationTests
{
    public class AuthenticatingWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove DbContextOptions
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                services.Remove(dbContextDescriptor);

                // remove DbConnection
                var dbConnectionDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbConnection));
                services.Remove(dbConnectionDescriptor);

                // Create open SqliteConnection so EF won't automatically close it.
                // this is needed because once disconnected, in memory db is reset
                services.AddSingleton((Func<IServiceProvider, DbConnection>)(container =>
                {
                    var connection = new SqliteConnection("DataSource=:memory:");
                    connection.Open();

                    return connection;
                }));

                services.AddDbContext<ApplicationDbContext>((container, optBuilder) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    optBuilder.UseSqlite(connection);

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

            context.Users.Add(new IdentityUser() { Id = "1", UserName = "onur", Email = "onur@mail.com" });

            context.SaveChanges();

        }
    }
}
