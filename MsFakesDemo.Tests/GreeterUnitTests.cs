using FluentAssertions;
using Microsoft.QualityTools.Testing.Fakes;
using System.Text.Json;

namespace MsFakesDemo.Tests
{
    public class GreeterUnitTests
    {
        [Theory]
        [InlineData(02, 00, "İyi geceler")]
        [InlineData(09, 00, "Günaydın")]
        [InlineData(11, 00, "İyi günler")]
        [InlineData(12, 15, "İyi günler")]
        [InlineData(19, 00, "İyi akşamlar")]
        [InlineData(23, 59, "İyi geceler")]
        public void TestGreeter(int hours, int minutes, string expected)
        {
            using (ShimsContext.Create())
            {
                // Arrange
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 11, 05, hours, minutes, 00);

                var sut = new Greeter();

                // Act
                var result = sut.Greet();

                // Assert
                result.Should().Be(expected);
            }
        }

      
    }
}