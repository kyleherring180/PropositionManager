using PropositionManager.Model.Entities;

namespace PropositionManager.ModelTests;

public class SupplierTests
{
    [Fact]
    public void Constructor_WithValidName_CreatesSupplier()
    {
        // Arrange
        var name = "Test Supplier";

        // Act
        var supplier = new Supplier(name);

        // Assert
        Assert.Equal(name, supplier.Name);
        Assert.Empty(supplier.Propositions);
        Assert.Empty(supplier.Prices);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithInvalidName_ThrowsArgumentException(string invalidName)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new Supplier(invalidName));
        Assert.Equal("Supplier name cannot be null or empty. (Parameter 'name')", exception.Message);
    }

    [Fact]
    public void UpdateName_WithValidName_UpdatesName()
    {
        // Arrange
        var supplier = new Supplier("Old Name");
        var newName = "New Name";

        // Act
        supplier.UpdateName(newName);

        // Assert
        Assert.Equal(newName, supplier.Name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void UpdateName_WithInvalidName_ThrowsArgumentException(string invalidName)
    {
        // Arrange
        var supplier = new Supplier("Valid Name");

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => supplier.UpdateName(invalidName));
        Assert.Equal("Supplier name cannot be null or empty. (Parameter 'name')", exception.Message);
    }

    [Fact]
    public void Propositions_ReturnsReadOnlyCollection()
    {
        // Arrange
        var supplier = new Supplier("Test Supplier");

        // Act & Assert
        Assert.IsAssignableFrom<IReadOnlyCollection<Proposition>>(supplier.Propositions);
    }

    [Fact]
    public void Prices_ReturnsReadOnlyCollection()
    {
        // Arrange
        var supplier = new Supplier("Test Supplier");

        // Act & Assert
        Assert.IsAssignableFrom<IReadOnlyCollection<Price>>(supplier.Prices);
    }
}

