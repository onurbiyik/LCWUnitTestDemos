using AspCore7App.Data;
using AspCore7App.Models;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AspCore7App.IntegrationTests.D_TestContainers
{
    public class TestContainerApplicationFactory<TProgram, TDbContext> 
        : WebApplicationFactory<TProgram>, IAsyncLifetime
            where TProgram : class 
            where TDbContext : DbContext
    {
        protected readonly TestcontainerDatabase _container;

        public TestContainerApplicationFactory()
        {
            _container = new TestcontainersBuilder<MsSqlTestcontainer>()
                 .WithDatabase(new MsSqlTestcontainerConfiguration
                 {
                     Password = "localdevpassword#123",
                 })
            .WithImage("mcr.microsoft.com/mssql/server:2019-latest")
            .WithCleanUp(true)
            .Build();

        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveDbContext<TDbContext>();
                services.AddDbContext<TDbContext>(options => { 
                    options.
                    UseSqlServer(_container.ConnectionString + ";TrustServerCertificate=True");
                });

                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<TDbContext>();

                SeedData(context);
            });
        }

        private static void SeedData(TDbContext context)
        {
            context.Database.EnsureCreated();

            context.AddRange(
                new Country { Name = "Türkiye", Population = 123456789 },
                new Country { Name = "Japonya", Population = 3333 },
                new Country { Name = "Estonya", Population = 66666 },
                new Country { Name = "Namibia", Population = 55555 });

            context.SaveChanges();

        }


        public async Task InitializeAsync() => await _container.StartAsync();

        public new async Task DisposeAsync() => await _container.DisposeAsync();
    }

    public static class ServiceCollectionExtensions
    {
        public static void RemoveDbContext<T>(this IServiceCollection services) where T : DbContext
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<T>));
            if (descriptor != null) services.Remove(descriptor);
        }
    }
}
