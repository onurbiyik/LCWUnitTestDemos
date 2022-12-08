using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AspCore7App.IntegrationTests.E_AuthenticationTests
{
    // todo: pick a strategy and mock sql. maybe in-memory
    // https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0#mock-authentication

    public class AuthenticationTests : IClassFixture<AuthenticatingWebApplicationFactory<Program>>
    {
        private readonly AuthenticatingWebApplicationFactory<Program> _factory;

        public AuthenticationTests(AuthenticatingWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }



        [Fact]
        public async Task Get_SecurePageRedirectsAnUnauthenticatedUser()
        {
            // Arrange
            var client = _factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });

            // Act
            var response = await client.GetAsync("/MemberInfo");

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Contains("/Identity/Account/Login", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task Get_SecurePageIsReturnedForAnAuthenticatedUser()
        {
            // Arrange
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication(defaultScheme: "TestScheme")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                            "TestScheme", options => { });
                });
            })
                .CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false,
                });

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "TestScheme");

            //Act
            var response = await client.GetAsync("/MemberInfo");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseHtml = await response.Content.ReadAsStringAsync();
            Assert.Contains("Welcome Test user", responseHtml);
            
        }
    }
}
