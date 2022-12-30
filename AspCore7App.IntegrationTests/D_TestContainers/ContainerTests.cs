using AspCore7App.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using System;

namespace AspCore7App.IntegrationTests.D_TestContainers
{
    public class ContainerTests : ContainerTestBase
    {
        private readonly TestContainerApplicationFactory<Program, ApplicationDbContext> _factory;

        public ContainerTests(TestContainerApplicationFactory<Program, ApplicationDbContext> factory) : base(factory)
        {
            _factory = factory;
            var scope = factory.Services.CreateScope();
            // _someService = scope.ServiceProvider.GetRequiredService<SomeService>();
        }


        [Fact(Timeout = 100000)]
        public async Task Get_CountriesPage_Returns3Countries()
        {
            // Arrange
            // CreateTestDate(base.DbContext);
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Countries");
            var responseHtml = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Contains("Namibia", responseHtml);
        }

       
    }
}
