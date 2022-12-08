using AspCore7App.Data;
using AspCore7App.IntegrationTests.C_NonProd_Readonly;
using AspCore7App.IntegrationTests.D_NonProd_InMemorySQL;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AspCore7App.IntegrationTests.C_NonProd_SQLite
{
    public class NonProdSQLiteTests : IClassFixture<SQLiteWebApplicationFactory<Program>>
    {
        private readonly SQLiteWebApplicationFactory<Program> _factory;

        public NonProdSQLiteTests(SQLiteWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task Get_CountriesPage_Returns3Countries()
        {
            // Arrange
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
