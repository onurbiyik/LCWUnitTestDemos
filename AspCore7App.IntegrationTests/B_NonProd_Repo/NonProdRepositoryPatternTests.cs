using AspCore7App.Models;
using AspCore7App.Pages;
using Moq;
using System.Reflection.Metadata;

namespace AspCore7App.IntegrationTests.B_NonProd_Repo
{
    public class NonProdRepositoryPatternTests
    {
        [Fact]
        public async Task GetCountries()
        {
            // Arrange
            var repositoryMock = new Mock<ICountryRepository>();
            repositoryMock
                .Setup(r => r.GetAllCountries())
                .Returns(new[] { 
                    new Country { Id = 1, Name = "Türkiye", Population = 80000000 },
                    new Country { Id = 2, Name = "Japonya", Population = 40000000 },
                    new Country { Id = 3, Name = "Kazakistan", Population = 34000000 },
                    new Country { Id = 4, Name = "Yemen", Population = 12000000 },
                });

            var page = new CountriesUsingRepositoryPatternModel(repositoryMock.Object);

            // Act
            await page.OnGetAsync();
            

            // Assert
            repositoryMock.Verify(r => r.GetAllCountries()); // make sure mock is called
            repositoryMock.Verify(r => r.GetAllCountries(), Times.Once); // make sure db is called only once
            Assert.Equal(3, page.Country.Count()); // only 3 countries should be selected
        }
    }
}
