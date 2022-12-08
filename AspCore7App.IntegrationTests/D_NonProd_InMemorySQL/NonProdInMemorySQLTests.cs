namespace AspCore7App.IntegrationTests.D_NonProd_InMemorySQL
{
    // DO NOT USE IN MEMORY FOR TESTING
    public class NonProdInMemorySQLTests : IClassFixture<InMemorySQLWebApplicationFactory<Program>>
    {
        private readonly InMemorySQLWebApplicationFactory<Program> _factory;

        public NonProdInMemorySQLTests(InMemorySQLWebApplicationFactory<Program> factory)
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
