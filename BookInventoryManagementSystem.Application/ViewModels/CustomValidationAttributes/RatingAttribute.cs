namespace BookInventoryManagementSystem.Application.ViewModels.CustomValidationAttributes;

public class RatingAttribute : RangeAttribute
{
    public RatingAttribute() : base(1, 5)
    {
    }

    public override string FormatErrorMessage(string rating)
    {
        return $"The {rating} must be between {Minimum} and {Maximum}, where {Maximum} is best.";
    }
}
