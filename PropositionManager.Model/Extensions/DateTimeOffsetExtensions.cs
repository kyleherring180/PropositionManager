namespace PropositionManager.Model.Extensions;

public static class DateTimeOffsetExtensions
{
    // private const string DutchTimeZoneIdMac = "Europe/Amsterdam"; // for Linux/MacOS
    private const string DutchTimeZoneId = "W. Europe Standard Time"; // for Windows
    
    public static DateTimeOffset ToDutchDateTimeOffset(this DateTimeOffset dateTimeOffset)
    {
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(DutchTimeZoneId);
        return TimeZoneInfo.ConvertTime(dateTimeOffset, timeZoneInfo);
    }
}