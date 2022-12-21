using Basics;
    
namespace Basics.Tests;

public class HeceTests
{
    [Fact]
    public void TestOnur()
    {
        // Arrange

        // Act
        var result = "onur".Hecele();

        // Assert
        Assert.Equal(new[] { "o", "nur" }, result);
    }


    [Fact(Skip = "Skipped for now")]
    public void TestAraba()
    {
        // Arrange

        // Act
        var result = "Araba".Hecele();

        // Assert
        Assert.Equal(new[] { "a", "ra", "ba" }, result);
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
    [Trait("Category", "L0")]
    [Trait("Case", "Edge")]

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
    [Trait("Category", "L0")]
    [Trait("Case", "Edge")]
    public void Hecele_WithNullString_ShouldThrowException()
    {
        // Arrange
        string? input = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => input.Hecele());
    }
}