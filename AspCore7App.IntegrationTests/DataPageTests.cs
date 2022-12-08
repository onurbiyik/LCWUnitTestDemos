using Microsoft.AspNetCore.Mvc.Testing;

namespace AspCore7App.IntegrationTests
{
    public class DataPageTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public DataPageTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
    }
}
