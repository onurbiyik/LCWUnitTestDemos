using AspCore7App.Data;
using Microsoft.AspNetCore.TestHost;

namespace AspCore7App.IntegrationTests.D_TestContainers
{
    public class ContainerTestBase : IClassFixture<TestContainerApplicationFactory<Program, ApplicationDbContext>>
    {
        public readonly TestContainerApplicationFactory<Program, ApplicationDbContext> Factory;
        public readonly ApplicationDbContext DbContext;

        public ContainerTestBase(TestContainerApplicationFactory<Program, ApplicationDbContext> factory)
        {
            Factory = factory;
            var scope = factory.Services.CreateScope();
            DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // you might as well Seed dbContext here
        }


    }
}
