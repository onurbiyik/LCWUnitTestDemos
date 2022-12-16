using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AspCore7App.IntegrationTests.F_Verify
{
    [UsesVerify]
    public class FluentAndVerifyTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public FluentAndVerifyTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task TestPrivacy()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/privacy");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType!.ToString());
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("privacy policy", content);
        }


        [Fact]
        public async Task TestPrivacy_Fluent()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/privacy");

            // Assert
            response.Should().Be2XXSuccessful()
                .And.HaveHeader("Content-Type").And.BeValues(new[] { "text/html; charset=utf-8" })
                .And.MatchInContent("*privacy policy*");
        }

        [Fact]
        public async Task TestPrivacy_Verify()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/privacy");

            // Assert
            await Verify(response);
                // .IgnoreMembers("Version");
        }

    }
}
