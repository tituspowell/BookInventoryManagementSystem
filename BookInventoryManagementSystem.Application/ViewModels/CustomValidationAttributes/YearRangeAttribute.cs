namespace BookInventoryManagementSystem.Application.ViewModels.CustomValidationAttributes;

public class YearRangeAttribute : RangeAttribute
{
    public YearRangeAttribute() : base(1000, DateTime.Now.Year)
    {
    }

    public override string FormatErrorMessage(string year)
    {
        return $"The {year} must be between {Minimum} and {Maximum}.";
    }
}

