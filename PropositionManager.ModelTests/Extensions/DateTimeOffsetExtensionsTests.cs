using PropositionManager.Model.Extensions;

namespace PropositionManager.ModelTests.Extensions;

public class DateTimeOffsetExtensionsTests
{
    [InlineData("2024-06-10 12:00:00 +00:00", "2024-06-10 14:00:00 +02:00")]
    [InlineData("2024-07-10 10:00:00 +01:00", "2024-07-10 11:00:00 +02:00")]
    [InlineData("2024-03-31 00:00:00 +00:00", "2024-03-31 01:00:00 +01:00")]
    [InlineData("2024-10-27 00:00:00 +00:00", "2024-10-27 02:00:00 +02:00")]
    [InlineData("2024-10-27 01:00:00 +00:00", "2024-10-27 02:00:00 +01:00")]
    [InlineData("2024-10-27 02:00:00 +00:00", "2024-10-27 03:00:00 +01:00")]
    [Theory]
    public void ToDutchDateTimeOffsetForDateTimeOffset(string inputDate, string expectedOutput)
    {
        //Arrange
        var date = DateTimeOffset.Parse(inputDate);

        // Act
        DateTimeOffset result = date.ToDutchDateTimeOffset();

        //Assert
        Assert.Equal(DateTimeOffset.Parse(expectedOutput), result);
    }
}