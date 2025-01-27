namespace BookInventoryManagementSystem.Data.Entities;

public class Review : BaseEntity
{
    public required int RatingOutOfFive { get; set; } // Rating could be a float to allow 4.5 for example but we force whole numbers for simplicity
    public required string ReviewText { get; set; }

    // Foreign Keys
    public required Book Book { get; set; }
    public required int BookId { get; set; }

    public required ApplicationUser Reviewer { get; set; }
    public required string ReviewerId { get; set; }
}
