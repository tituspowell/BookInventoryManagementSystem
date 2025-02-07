using BookInventoryManagementSystem.Application.ViewModels.CustomValidationAttributes;
using System.ComponentModel;

namespace BookInventoryManagementSystem.Application.ViewModels.Reviews;

public class ReviewCreateViewModel
{
    // All the common fields for a book, excluding ID since that's not always needed in the various view models
    [Required]
    [DisplayName("Rating (out of 5, where 5 is best)")]
    //[Rating] // Probably didn't need the custom attribute!
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int RatingOutOfFive { get; set; } // Rating could be a float to allow 4.5 for example but we force whole numbers for simplicity

    [Required]
    [DisplayName("Review")]
    [DataType(DataType.MultilineText)]
    public string ReviewText { get; set; }

    // Hidden fields
    public required int BookId { get; set; }
    public required string ReviewerId { get; set; }
}
