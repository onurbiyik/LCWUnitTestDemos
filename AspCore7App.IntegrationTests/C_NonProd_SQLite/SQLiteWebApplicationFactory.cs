using AspCore7App.Data;
using AspCore7App.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection.Metadata;

namespace AspCore7App.IntegrationTests.C_NonProd_Readonly
{
    public class SQLiteWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
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
                services.AddSingleton<DbConnection>(container =>
                {
                    var connection = new SqliteConnection("DataSource=:memory:");
                    connection.Open();

                    return connection;
                });

                services.AddDbContext<ApplicationDbContext>((container, optBuilder) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    optBuilder.UseSqlite(connection);
                    
                    
                    var ctxOptions = optBuilder.Options;

                    // Create the schema and seed some data
                    //using var context = new ApplicationDbContext(ctxOptions);

                    //context.AddRange(
                    //    new Country { Id = 1, Name = "Türkiye", Population = 123456789 },
                    //    new Country { Id = 2, Name = "Namibia", Population = 555 });
                    //context.SaveChanges();
                });


            });
           

            builder.UseEnvironment("Development");
        }
    }
}
