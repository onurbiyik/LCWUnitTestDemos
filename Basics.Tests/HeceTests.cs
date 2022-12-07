using Basics;
    
namespace Basics.Tests;

public class HeceTests
{
    [Fact]
    public void Test1()
    {
        // Arrange

        // Act
        var result = "onur".Hecele();

        // Assert
        Assert.Equal(new[] { "o", "nur" }, result);
    }


    [Theory]
    [InlineData("onur", new[] { "o", "nur"})]
    [InlineData("vergi", new[] { "ver", "gi" })]
    [InlineData("sarımtrak", new[] { "sa", "rım", "trak" })]
    [InlineData("Mert", new[] { "Mert" })]
    [InlineData("Kartpostal", new[] { "Kart", "pos", "tal" })]
    [InlineData("Vergi kutsaldır", new[] { "Ver", "gi", "kut", "sal", "dır" })]
    [InlineData("Her Koyun Kendi Bacağından Asılır", new[] { "Her", "Ko", "yun", "Ken", "di", "Ba", "ca", "ğın", "dan", "A", "sı", "lır" })]
    public void Test2(string input, IEnumerable<string> expected)
    {
        var result = input.Hecele();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Hecele_WithEmptyString_ShouldReturnEmptyList()
    {
        // Arrange
        string input = "";

        // Act
        var result = input.Hecele();

        // Assert
        Assert.Equal(new string[] { }, result);
    }


    [Fact]
    public void Hecele_WithNullString_ShouldThrowException()
    {
        // Arrange
        string? input = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => input.Hecele());
    }
}