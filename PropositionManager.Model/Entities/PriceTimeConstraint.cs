using System.Collections.ObjectModel;
using PropositionManager.Model.Enums;

namespace PropositionManager.Model.Entities;

public class PriceTimeConstraint
{
    private readonly List<PriceTimeConstraintPrice> _priceTimeConstraintPrices = new();

    public Guid Id { get; init; }
    public string Name { get; private set; }
    public DaysOfWeek DaysOfWeek { get; private set; }
    public DateOnly FromDate { get; private set; }
    public DateOnly UntilDate { get; private set; }
    public TimeOnly FromTime { get; private set; }
    public TimeOnly UntilTime { get; private set; }
    
    public IReadOnlyCollection<PriceTimeConstraintPrice> PriceTimeConstraintPrices => _priceTimeConstraintPrices.AsReadOnly();

    private PriceTimeConstraint() { /*Required for EF Core */ }

    public PriceTimeConstraint(string name, DaysOfWeek daysOfWeek, DateOnly fromDate, DateOnly untilDate, TimeOnly fromTime, TimeOnly untilTime)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
            
        if (daysOfWeek == DaysOfWeek.None)
            throw new ArgumentException("At least one day must be selected", nameof(daysOfWeek));
            
        if (fromDate > untilDate)
            throw new ArgumentException("FromDate must be before or equal to UntilDate");
            
        if (fromTime >= untilTime)
            throw new ArgumentException("FromTime must be before UntilTime");

        Id = Guid.NewGuid();
        Name = name;
        DaysOfWeek = daysOfWeek;
        FromDate = fromDate;
        UntilDate = untilDate;
        FromTime = fromTime;
        UntilTime = untilTime;
    }

    public bool IsActiveOn(DayOfWeek dayOfWeek)
    {
        var day = (DaysOfWeek)(1 << ((int)dayOfWeek));
        return DaysOfWeek.HasFlag(day);
    }

    public bool IsActiveAt(DateTime dateTime)
    {
        var date = DateOnly.FromDateTime(dateTime);
        var time = TimeOnly.FromDateTime(dateTime);
        
        return IsActiveOn(dateTime.DayOfWeek) &&
               date >= FromDate && 
               date <= UntilDate &&
               time >= FromTime && 
               time < UntilTime;
    }
}

